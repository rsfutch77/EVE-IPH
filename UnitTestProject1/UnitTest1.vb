Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports EVE_Isk_per_Hour

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        Dim form1 As New frmMain

        Assert.AreEqual(2, 2)

    End Sub

End Class