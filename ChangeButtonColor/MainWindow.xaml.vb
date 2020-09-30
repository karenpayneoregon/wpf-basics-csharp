Class MainWindow
    Public Shared ExitRoutedCommand As New RoutedCommand()
    Private Sub ExitApplicationCommandOnExecute(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        Application.Current.Shutdown()
    End Sub

    Private Sub ApplicationExitCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
        e.CanExecute = True
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        CommandBindings.Add(New CommandBinding(ExitRoutedCommand, AddressOf ExitApplicationCommandOnExecute, AddressOf ApplicationExitCanExecute))
    End Sub
End Class
