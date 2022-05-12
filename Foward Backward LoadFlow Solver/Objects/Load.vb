Imports System.Numerics

Public Class Load
    Inherits Node

    Public powerA As Complex
    Public powerB As Complex
    Public powerC As Complex
    Public cpq As Double
    Public cc As Double
    Public ci As Double

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
        Dim voltage As String()
        voltage = parameters(0).Split(New Char() {"+"c})
        Me.powerA = New Complex(voltage(0), voltage(1).Replace("j", 0))
        voltage = parameters(1).Split(New Char() {"+"c})
        Me.powerB = New Complex(voltage(0), voltage(1).Replace("j", 0))
        voltage = parameters(2).Split(New Char() {"+"c})
        Me.powerC = New Complex(voltage(0), voltage(1).Replace("j", 0))
        Me.cpq = parameters(3)
        Me.cc = parameters(4)
        Me.ci = parameters(5)
    End Sub

    Public Sub New(dbID As Integer)
        Me.dbID = dbID

        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("SELECT * FROM loads WHERE ID=" & dbID, con)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Me.title = READER("title")
                Me.description = READER("description")
                Me.powerA = New Complex(READER("powerA_R"), READER("powerA_I"))
                Me.powerB = New Complex(READER("powerB_R"), READER("powerB_I"))
                Me.powerC = New Complex(READER("powerC_R"), READER("powerC_I"))
                Me.cpq = READER("cpq")
                Me.cc = READER("cc")
                Me.ci = READER("ci")
            End While
            con.Close()
        Catch ex As Exception
            frmMain.addLog(ex.Message, Color.Red)
            con.Dispose()
        End Try
    End Sub

    Public Function getParameters() As String
        Dim parameters = powerA.Real.ToString + "+" + powerA.Imaginary.ToString + "j," + powerB.Real.ToString + "+" + powerB.Imaginary.ToString + "j," + powerC.Real.ToString + "+" + powerC.Imaginary.ToString + "j,"
        parameters += Me.cpq.ToString + "," + Me.cc.ToString + "," + Me.ci.ToString
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
            COMMAND = New OleDb.OleDbCommand("INSERT INTO loads (title, description, powerA_R, powerA_I, powerB_R, powerB_I, powerC_R, powerC_I, cpq, cc, ci) VALUES(@title, @description, @powerA_R, @powerA_I, @powerB_R, @powerB_I, @powerC_R, @powerC_I, @cpq, @cc, @ci)", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("powerA_R", powerA.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerA_I", powerA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerB_R", powerB.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerB_I", powerB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerC_R", powerC.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerC_I", powerC.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("cpq", cpq)
            COMMAND.Parameters.AddWithValue("cc", cc)
            COMMAND.Parameters.AddWithValue("ci", ci)
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
            COMMAND = New OleDb.OleDbCommand("UPDATE loads SET title=@title, description=@description, powerA_R=@powerA_R, powerA_I=@powerA_I, powerB_R=@powerB_R, powerB_I=@powerB_I, powerC_R=@powerC_R, powerC_I=@powerC_I, cpq=@cpq, cc=@cc, ci=@ci WHERE ID=@dbID", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("powerA_R", powerA.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerA_I", powerA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerB_R", powerB.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerB_I", powerB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("powerC_R", powerC.Real.ToString)
            COMMAND.Parameters.AddWithValue("powerC_I", powerC.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("cpq", cpq)
            COMMAND.Parameters.AddWithValue("cc", cc)
            COMMAND.Parameters.AddWithValue("ci", ci)
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
