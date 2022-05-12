Imports System.Numerics

Public Class Line
    Inherits Edge

    Public type As String = "Overhead"
    Public resistance_p As Double = 0
    Public gmr_p As Double = 0
    Public resistance_n As Double = 0
    Public gmr_n As Double = 0
    Public phases As Integer = 3
    Public length As Double = 1
    Public isNeutralAvailable As Boolean = True
    Public frequency As Integer = 50
    Public soilResistivity As Double = 100

    Public L_12 As Double = 0
    Public L_13 As Double = 0
    Public L_23 As Double = 0
    Public L_1N As Double = 0
    Public L_2N As Double = 0
    Public L_3N As Double = 0

    Public Sub New()

    End Sub

    Public Sub New(startNode As String, endNode As String, parameterString As String)
        Me.startNode = startNode
        Me.endNode = endNode

        Dim parameters As String() = parameterString.Split(New Char() {","c})
        Me.resistance_p = parameters(0)
        Me.gmr_p = parameters(1)
        Me.resistance_n = parameters(2)
        Me.gmr_n = parameters(3)
        Me.phases = parameters(4)
        Me.length = parameters(5)
        Me.isNeutralAvailable = parameters(6)
        Me.frequency = parameters(7)
        Me.soilResistivity = parameters(8)
        Me.type = parameters(9)
        Me.L_12 = parameters(10)
        Me.L_13 = parameters(11)
        Me.L_23 = parameters(12)
        Me.L_1N = parameters(13)
        Me.L_2N = parameters(14)
        Me.L_3N = parameters(15)

        If type = "O" Then
            Me.type = "Overhead"
        Else
            Me.type = "Underground"
        End If

    End Sub

    Public Sub New(dbID As Integer)
        Me.dbID = dbID

        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("SELECT * FROM lines WHERE ID=" & dbID, con)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Me.title = READER("title")
                Me.description = READER("description")
                Me.resistance_p = READER("resistance_p")
                Me.gmr_p = READER("gmr_p")
                Me.resistance_n = READER("resistance_n")
                Me.gmr_n = READER("gmr_n")
                Me.phases = READER("phases")
                Me.length = READER("length")
                Me.isNeutralAvailable = READER("isNeutralAvailable")
                Me.frequency = READER("frequency")
                Me.soilResistivity = READER("soilResistivity")
                Me.type = READER("type")
                Me.L_12 = READER("l_12")
                Me.L_13 = READER("l_13")
                Me.L_23 = READER("l_23")
                Me.L_1N = READER("l_1n")
                Me.L_2N = READER("l_2n")
                Me.L_3N = READER("l_3n")
            End While
            con.Close()
        Catch ex As Exception
            frmMain.addLog(ex.Message, Color.Red)
            con.Dispose()
        End Try
    End Sub

    Public Function getParameters() As String
        Dim parameters = resistance_p.ToString + "," + gmr_p.ToString + "," + resistance_n.ToString + "," + gmr_n.ToString + "," + phases.ToString + "," + length.ToString + "," + isNeutralAvailable.ToString + "," + frequency.ToString + "," + soilResistivity.ToString + ","
        If type = "Overhead" Then
            parameters += "O,"
        Else
            parameters += "U,"
        End If
        parameters += L_12.ToString + "," + L_13.ToString + "," + L_23.ToString + "," + L_1N.ToString + "," + L_2N.ToString + "," + L_3N.ToString
        Return parameters
    End Function

    Public Sub addToDatabase()
        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("INSERT INTO lines (title, description, resistance_p, resistance_n, gmr_p, gmr_n, phases, length, isNeutralAvailable,frequency, soilResistivity, type,l_12, l_13, l_23, l_1n, l_2n, l_3n) VALUES(@title, @description, @resistance_p, @resistance_n, @gmr_p, @gmr_n, @phases, @length, @isNeutralAvailable, @frequency, @soilResistivity, @type, @l_12, @l_13, @l_23, @l_1n, @l_2n, @l_3n)", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("resistance_p", resistance_p)
            COMMAND.Parameters.AddWithValue("gmr_p", gmr_p)
            COMMAND.Parameters.AddWithValue("resistance_n", resistance_n)
            COMMAND.Parameters.AddWithValue("gmr_n", gmr_n)
            COMMAND.Parameters.AddWithValue("phases", phases)
            COMMAND.Parameters.AddWithValue("length", length)
            COMMAND.Parameters.AddWithValue("isNeutralAvailable", isNeutralAvailable)
            COMMAND.Parameters.AddWithValue("frequency", frequency)
            COMMAND.Parameters.AddWithValue("soilResistivity", soilResistivity)
            COMMAND.Parameters.AddWithValue("type", type)
            COMMAND.Parameters.AddWithValue("l_12", L_12)
            COMMAND.Parameters.AddWithValue("l_13", L_13)
            COMMAND.Parameters.AddWithValue("l_23", L_23)
            COMMAND.Parameters.AddWithValue("l_1n", L_1N)
            COMMAND.Parameters.AddWithValue("l_2n", L_2N)
            COMMAND.Parameters.AddWithValue("l_3n", L_3N)
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
            COMMAND = New OleDb.OleDbCommand("UPDATE lines SET title=@title, description=@description, resistance_p=@resistance_p, resistance_n=@resistance_n, gmr_p=@gmr_p, gmr_n=@gmr_n, phases=@phases, length=@length, isNeutralAvailable=@isNeutralAvailable,frequency=@frequency, soilResistivity=@soilResistivity, type=@type,l_12=@l_12, l_13=@l_13, l_23=@l_23, l_1n=@l_1n, l_2n=@l_2n, l_3n=@l_3n WHERE ID=@dbID", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("resistance_p", resistance_p)
            COMMAND.Parameters.AddWithValue("gmr_p", gmr_p)
            COMMAND.Parameters.AddWithValue("resistance_n", resistance_n)
            COMMAND.Parameters.AddWithValue("gmr_n", gmr_n)
            COMMAND.Parameters.AddWithValue("phases", phases)
            COMMAND.Parameters.AddWithValue("length", length)
            COMMAND.Parameters.AddWithValue("isNeutralAvailable", isNeutralAvailable)
            COMMAND.Parameters.AddWithValue("frequency", frequency)
            COMMAND.Parameters.AddWithValue("soilResistivity", soilResistivity)
            COMMAND.Parameters.AddWithValue("type", type)
            COMMAND.Parameters.AddWithValue("l_12", L_12)
            COMMAND.Parameters.AddWithValue("l_13", L_13)
            COMMAND.Parameters.AddWithValue("l_23", L_23)
            COMMAND.Parameters.AddWithValue("l_1n", L_1N)
            COMMAND.Parameters.AddWithValue("l_2n", L_2N)
            COMMAND.Parameters.AddWithValue("l_3n", L_3N)
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
