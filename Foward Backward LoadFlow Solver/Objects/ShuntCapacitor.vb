Imports System.Numerics

Public Class ShuntCapacitor
    Inherits Node

    Public voltageA As Complex
    Public voltageB As Complex
    Public voltageC As Complex
    Public kvarA As Complex
    Public kvarB As Complex
    Public kvarC As Complex

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
        Me.voltageA = New Complex(voltage(0), voltage(1).Replace("j", 0))
        voltage = parameters(1).Split(New Char() {"+"c})
        Me.voltageB = New Complex(voltage(0), voltage(1).Replace("j", 0))
        voltage = parameters(2).Split(New Char() {"+"c})
        Me.voltageC = New Complex(voltage(0), voltage(1).Replace("j", 0))
        Dim power As String()
        power = parameters(3).Split(New Char() {"+"c})
        Me.kvarA = New Complex(power(0), power(1).Replace("j", 0))
        power = parameters(4).Split(New Char() {"+"c})
        Me.kvarB = New Complex(power(0), power(1).Replace("j", 0))
        power = parameters(5).Split(New Char() {"+"c})
        Me.kvarC = New Complex(power(0), power(1).Replace("j", 0))
    End Sub

    Public Sub New(dbID As Integer)
        Me.dbID = dbID

        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("SELECT * FROM capacitors WHERE ID=" & dbID, con)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Me.title = READER("title")
                Me.description = READER("description")
                Me.voltageA = New Complex(READER("voltageA_R"), READER("voltageA_I"))
                Me.voltageB = New Complex(READER("voltageB_R"), READER("voltageB_I"))
                Me.voltageC = New Complex(READER("voltageC_R"), READER("voltageC_I"))
                Me.kvarA = New Complex(READER("kvarA_R"), READER("kvarA_I"))
                Me.kvarB = New Complex(READER("kvarB_R"), READER("kvarB_I"))
                Me.kvarC = New Complex(READER("kvarC_R"), READER("kvarC_I"))
            End While
            con.Close()
        Catch ex As Exception
            frmMain.addLog(ex.Message, Color.Red)
            con.Dispose()
        End Try
    End Sub

    Public Function getParameters() As String
        Dim parameters = voltageA.Real.ToString + "+" + voltageA.Imaginary.ToString + "j," + voltageB.Real.ToString + "+" + voltageB.Imaginary.ToString + "j," + voltageC.Real.ToString + "+" + voltageC.Imaginary.ToString + "j,"
        parameters += kvarA.Real.ToString + "+" + kvarA.Imaginary.ToString + "j," + kvarB.Real.ToString + "+" + kvarB.Imaginary.ToString + "j," + kvarC.Real.ToString + "+" + kvarC.Imaginary.ToString + "j,"
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
            COMMAND = New OleDb.OleDbCommand("INSERT INTO capacitors (title, description, voltageA_R, voltageA_I, voltageB_R, voltageB_I, voltageC_R, voltageC_I, kvarA_R, kvarA_I, kvarB_R, kvarB_I, kvarC_R, kvarC_I) VALUES(@title, @description, @voltageA_R, @voltageA_I, @voltageB_R, @voltageB_I, @voltageC_R, @voltageC_I, @kvarA_R, @kvarA_I, @kvarB_R, @kvarB_I, @kvarC_R, @kvarC_I)", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("voltageA_R", voltageA.Real.ToString)
            COMMAND.Parameters.AddWithValue("voltageA_I", voltageA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("voltageB_R", voltageB.Real.ToString)
            COMMAND.Parameters.AddWithValue("voltageB_I", voltageB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("voltageC_R", voltageC.Real.ToString)
            COMMAND.Parameters.AddWithValue("voltageC_I", voltageC.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("kvarA_R", kvarA.Real.ToString)
            COMMAND.Parameters.AddWithValue("kvarA_I", kvarA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("kvarB_R", kvarB.Real.ToString)
            COMMAND.Parameters.AddWithValue("kvarB_I", kvarB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("kvarC_R", kvarC.Real.ToString)
            COMMAND.Parameters.AddWithValue("kvarC_I", kvarC.Imaginary.ToString)
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
            COMMAND = New OleDb.OleDbCommand("UPDATE loads SET title=@title, description=@description, voltageA_R=@voltageA_R, voltageA_I=@voltageA_I, voltageB_R=@voltageB_R, voltageB_I=@voltageB_I, voltageC_R=@voltageC_R, voltageC_I=@voltageC_I, kvarA_R=@kvarA_R, kvarA_I=@kvarA_I, kvarB_R=@kvarB_R, kvarB_I=@kvarB_I, kvarC_R=@kvarC_R, kvarC_I=@kvarC_I WHERE ID=@dbID", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("voltageA_R", voltageA.Real.ToString)
            COMMAND.Parameters.AddWithValue("voltageA_I", voltageA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("voltageB_R", voltageB.Real.ToString)
            COMMAND.Parameters.AddWithValue("voltageB_I", voltageB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("voltageC_R", voltageC.Real.ToString)
            COMMAND.Parameters.AddWithValue("voltageC_I", voltageC.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("kvarA_R", kvarA.Real.ToString)
            COMMAND.Parameters.AddWithValue("kvarA_I", kvarA.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("kvarB_R", kvarB.Real.ToString)
            COMMAND.Parameters.AddWithValue("kvarB_I", kvarB.Imaginary.ToString)
            COMMAND.Parameters.AddWithValue("kvarC_R", kvarC.Real.ToString)
            COMMAND.Parameters.AddWithValue("kvarC_I", kvarC.Imaginary.ToString)
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
