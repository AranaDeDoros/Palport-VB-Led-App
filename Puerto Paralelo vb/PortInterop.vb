Imports System.Runtime.InteropServices ' No olvidar aquí.

Public Class PortInterop
    <DllImport("inpout32.dll", EntryPoint:="Out32")> _
    Public Shared Sub Output(ByVal adress As Integer, ByVal value As Integer)
    End Sub
    <DllImport("inpout32.dll", EntryPoint:="Inp32")> _
    Public Shared Function Input(ByVal adress As Integer) As Integer
    End Function
End Class
