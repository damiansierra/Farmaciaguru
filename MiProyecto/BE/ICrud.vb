Public Interface ICrud(Of T)
    Function alta(obj As T) As Boolean
    Function baja(obj As T) As Boolean
    Function modificacion(obj As T) As Boolean
    Function listarTodos() As List(Of T)
    Function listarPorId(obj As T) As T
End Interface
