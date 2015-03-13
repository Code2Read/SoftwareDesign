namespace Core.Modelo
{
    public enum ErrorCambioContrasena
    {
        LongitudMinimaInvalida,
        ComplejidadIncorrecta,
        ContrasenaRepetida,
    }

    public class ResultadoCambioContrasena
    {
        public bool ContrasenaActualizada { get; set; }
        public ErrorCambioContrasena Respuesta { get; set; }
    }
}
