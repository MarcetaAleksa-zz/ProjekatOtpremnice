Imports Microsoft.VisualBasic

Friend Class MyComboBox
    Inherits ComboBox

    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Dim mwe As HandledMouseEventArgs = DirectCast(e, HandledMouseEventArgs)
        mwe.Handled = True
    End Sub
End Class
