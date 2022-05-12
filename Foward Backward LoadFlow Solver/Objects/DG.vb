Imports System.Numerics

Public Class DG
    Inherits Node

    Public powerA As Complex
    Public powerB As Complex
    Public powerC As Complex
    Public pfA As Double
    Public pfB As Double
    Public pfC As Double

    Public Sub New()

    End Sub

    Public Sub New(node As String, connection As String, parameterString As String)
        Me.node = node
        If connection = "S" Then
            Me.connection = "Star"
        Else
            Me.connection = "Delta"
        End If

        Dim parameters As String() = parameterString.Split(New Char() {","c})
        Dim power As String()
        power = parameters(0).Split(New Char() {"+"c})
        Me.powerA = New Complex(power(0), power(1).Replace("j", 0))
        power = parameters(1).Split(New Char() {"+"c})
        Me.powerB = New Complex(power(0), power(1).Replace("j", 0))
        power = parameters(2).Split(New Char() {"+"c})
        Me.powerC = New Complex(power(0), power(1).Replace("j", 0))
        Me.pfA = parameters(3)
        Me.pfB = parameters(4)
        Me.pfC = parameters(5)
    End Sub

    Public Sub New(dbID As Integer)
        Me.dbID = dbID

        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("SELECT * FROM generators WHERE ID=" & dbID, con)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Me.title = READER("title")
                Me.description = READER("description")
                Me.powerA = New Complex(READER("powerA_R"), READER("powerA_I"))
                Me.powerB = New Complex(READER("powerB_R"), READER("powerB_I"))
                Me.powerC = New Complex(READER("powerC_R"), READER("powerC_I"))
                Me.pfA = READER("pfA")
                Me.pfB = READER("pfB")
                Me.pfC = READER("pfC")
            End While
            con.Close()
        Catch ex As Exception
            frmMain.addLog(ex.Message, Color.Red)
            con.Dispose()
        End Try
    End Sub

    Public Function getParameters() As String
        Dim parameters = powerA.Real.ToString + "+" + powerA.Imaginary.ToString + "j," + powerB.Real.ToString + "+" + powerB.Imaginary.ToString + "j," + powerC.Real.ToString + "+" + powerC.Imaginary.ToString + "j,"
        parameters += Me.pfA.ToString + "," + Me.pfB.ToString + "," + Me.pfC.ToString
        Return parameters
    End Function

    Public Function getConnection() As String
        If Me.connection = "Star" Then
            Return "S"
        Else
            Return "D"
        End If
    End Function

    Public Sub addToDatabase()
        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("INSERT INTO generators (title, description, powerA_R, powerA_I, powerB_R, powerB_I, powerC_R, powerC_I, pfA, pfB, pfC) VALUES(@title, @description, @powerA_R, @powerA_I, @powerB_R, @powerB_I, @powerC_R, @powerC_I, @pfA, @pfB, @pfC)", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("powerA_R", powerA.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerA_I", powerA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerB_R", powerB.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerB_I", powerB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerC_R", powerC.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerC_I", powerC.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("pfA", pfA)
            COMMAND.Parameters.AddWithValue("pfB", pfB)
            COMMAND.Parameters.AddWithValue("pfC", pfC)
            READER = COMMAND.ExecuteReader
            con.Close()
            frmMain.addLog("Model saved to database", Color.Green)
        Catch ex As Exception
            frmMain.addLog(ex.Message, Color.Red)
            con.Dispose()
        End Try
    End Sub

    Public Sub updateDatabase()
        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("UPDATE generators SET title=@title, description=@description, powerA_R=@powerA_R, powerA_I=@powerA_I, powerB_R=@powerB_R, powerB_I=@powerB_I, powerC_R=@powerC_R, powerC_I=@powerC_I, pfA=@pfA, pfB=@pfB, pfC=@pfC WHERE ID=@dbID", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("powerA_R", powerA.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerA_I", powerA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerB_R", powerB.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerB_I", powerB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerC_R", powerC.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerC_I", powerC.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("pfA", pfA)
            COMMAND.Parameters.AddWithValue("pfB", pfB)
            COMMAND.Parameters.AddWithValue("pfC", pfC)
            COMMAND.Parameters.AddWithValue("dbID", dbID)
            READER = COMMAND.ExecuteReader
            con.Close()
            frmMain.addLog("Model parameters updated", Color.Green)
        Catch ex As Exception
            frmMain.addLog(ex.Message, Color.Red)
            con.Dispose()
        End Try
    End Sub
End Class
