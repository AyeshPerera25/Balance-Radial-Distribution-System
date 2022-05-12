Public Class Transformer
    Inherits Edge

    Public power As Double
    Public primaryVoltage As Double
    Public secondaryVoltage As Double
    Public percentageImpedance As Double
    Public phaseAngle As Double
    Public xrRatio As Double
    Public type As String
    Public Sub New()

    End Sub

    Public Sub New(startNode As String, endNode As String, parameterString As String)
        Me.startNode = startNode
        Me.endNode = endNode

        Dim parameters As String() = parameterString.Split(New Char() {","c})
        Me.power = parameters(0)
        Me.primaryVoltage = parameters(1)
        Me.secondaryVoltage = parameters(2)
        Me.percentageImpedance = parameters(3)
        Me.xrRatio = parameters(4)
        Me.type = parameters(5)
        Me.phaseAngle = parameters(6)
    End Sub

    Public Sub New(dbID As Integer)
        Me.dbID = dbID

        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("SELECT * FROM transformers WHERE ID=" & dbID, con)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Me.title = READER("title")
                Me.description = READER("description")
                Me.power = READER("power")
                Me.primaryVoltage = READER("primaryVoltage")
                Me.secondaryVoltage = READER("secondaryVoltage")
                Me.percentageImpedance = READER("percentageImpedance")
                Me.xrRatio = READER("xrRatio")
                Me.type = READER("type")
                Me.phaseAngle = READER("phaseAngle")
            End While
            con.Close()
        Catch ex As Exception
            frmMain.addLog(ex.Message, Color.Red)
            con.Dispose()
        End Try
    End Sub

    Public Function getParameters() As String
        Dim parameters = power.ToString + "," + primaryVoltage.ToString + "," + secondaryVoltage.ToString + "," + percentageImpedance.ToString + "," + xrRatio.ToString + "," + type + "," + phaseAngle.ToString

        Return parameters
    End Function

    Public Sub addToDatabase()
        Dim con As New OleDb.OleDbConnection
        Dim READER As OleDb.OleDbDataReader
        Dim COMMAND As OleDb.OleDbCommand
        con.ConnectionString = Project.connectionString

        Try
            con.Open()
            COMMAND = New OleDb.OleDbCommand("INSERT INTO transformers (title, description, power, primaryVoltage, secondaryVoltage, percentageImpedance, xrRatio, type, phaseAngle) VALUES(@title, @description, @power, @primaryVoltage, @secondaryVoltage, @percentageImpedance, @xrRatio, @type, @phaseAngle)", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("power", power)
            COMMAND.Parameters.AddWithValue("primaryVoltage", primaryVoltage)
            COMMAND.Parameters.AddWithValue("secondaryVoltage", secondaryVoltage)
            COMMAND.Parameters.AddWithValue("percentageImpedance", percentageImpedance)
            COMMAND.Parameters.AddWithValue("xrRatio", xrRatio)
            COMMAND.Parameters.AddWithValue("type", type)
            COMMAND.Parameters.AddWithValue("phaseAngle", phaseAngle)
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
            COMMAND = New OleDb.OleDbCommand("UPDATE transformers SET title=@title, description=@description, power=@power, primaryVoltage=@primaryVoltage, secondaryVoltage=@secondaryVoltage, percentageImpedance=@percentageImpedance, xrRatio=@xrRatio, type=@type, phaseAngle=@phaseAngle WHERE ID=@dbID", con)
            COMMAND.Parameters.AddWithValue("title", title)
            COMMAND.Parameters.AddWithValue("description", description)
            COMMAND.Parameters.AddWithValue("power", power)
            COMMAND.Parameters.AddWithValue("primaryVoltage", primaryVoltage)
            COMMAND.Parameters.AddWithValue("secondaryVoltage", secondaryVoltage)
            COMMAND.Parameters.AddWithValue("percentageImpedance", percentageImpedance)
            COMMAND.Parameters.AddWithValue("xrRatio", xrRatio)
            COMMAND.Parameters.AddWithValue("type", type)
            COMMAND.Parameters.AddWithValue("phaseAngle", phaseAngle)
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
