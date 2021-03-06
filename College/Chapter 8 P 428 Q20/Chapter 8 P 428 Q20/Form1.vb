﻿
' 
' Copyright 2020, Kye Matzen, http://kyematzen.com
' <p>
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the
' Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software,
' and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
' <p>
' The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
' <p>
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
' MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
' ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
' THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
'

Public Class frmCowboys
    Private Sub btnCreateFile_Click(sender As Object, e As EventArgs) Handles btnUpdateFile.Click
        ' Checks if cowboy previously exists.
        If Not IO.File.Exists("Cowboy.txt") Then
            ' Creates cowboy product array with pricing
            Dim lines As String() = {"Colt Peacemaker,12.20", "Holster,2.00", "Levi Strauss jeans,1.35", "Saddle,40.00", "Stetson,10.00"}

            ' Writes cowboy file to project storage.
            IO.File.WriteAllLines("Cowboy.txt", lines)
        End If

        ' Reads cowboy file from project storage.
        Dim cowboyFile As String() = IO.File.ReadAllLines("Cowboy.txt")

        ' Loops from first index of cow boy file array to end to check for saddles.
        For index = 0 To cowboyFile.Count - 1 Step 1
            ' Grabs line of information at index of cowboy file
            Dim localLine = cowboyFile(index)

            ' Checks if localLine is a saddle.
            If (localLine.StartsWith("Saddle")) Then
                Dim lineSplit = localLine.Split(",")
                Dim amount As Double = CDbl(lineSplit(1))

                ' Reduces price of saddle by 20% and adds back into file at specific index.
                cowboyFile(index) = "Saddle," & (amount * 0.8)
                Exit For
            End If
        Next

        ' Writes cowboy file to project storage.
        IO.File.WriteAllLines("Cowboy.txt", cowboyFile)
    End Sub
End Class