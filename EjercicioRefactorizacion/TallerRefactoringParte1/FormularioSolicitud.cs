namespace TallerRefactoringParte1
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ArchivoAdjunto
    {
        public string Ruta { get; set; }
        public string Mime { get; set; }
    }

    public class Solicitud
    {
        public List<ArchivoAdjunto> ArchivosAdjuntos { get; set; }
        public string RolResponsable { get; set; }
        public int Tipo { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
    }

    public class RepositorioSolicitud
    {
        public void Guardar(Solicitud solicitud)
        {
        }
    }

public class FormularioSolicitud
{

    public void Registrar(Solicitud solicitud)
    {
        try
        {

            if (solicitud.FechaEnvio.Year > DateTime.Now.Year)
            {
                if (solicitud.Cantidad > 1000)
                {
                    if (solicitud.Tipo == 1)
                    {
                        solicitud.RolResponsable = "Responsable1";
                    }
                    else
                    {
                        solicitud.RolResponsable = "Responsable2";
                    }
                }
                else
                {
                    solicitud.RolResponsable = "Supervisor";
                }
            }
            else
            {
                solicitud.RolResponsable = "Administrador";
            }


            #region Validacion de archivo

            var erroresArchivos = string.Empty;

            foreach (var archivo in solicitud.ArchivosAdjuntos)
            {
                try
                {
                    if (ExisteArchivo(archivo.Ruta))
                    {

                        if (!ValidarArchivo(archivo.Ruta))
                        {
                            throw new ApplicationException("Extension no valida");
                        }

                        #region Obtener tipo mime

                        var extension = Path.GetExtension(archivo.Ruta);

                        switch (extension)
                        {
                            case ".pdf":
                                archivo.Mime = "application/pdf";
                                break;
                            case ".txt":
                                archivo.Mime = "text/plain";
                                break;
                            case ".xls":
                                archivo.Mime = "application/excel";
                                break;
                            case ".doc":
                                archivo.Mime = "application/msword";
                                break;
                            default:
                                archivo.Mime = "application/mime";
                                break;
                        }

                        #endregion
                    }
                }
                catch (ApplicationException exApp)
                {
                    erroresArchivos += exApp.Message;
                }
                catch (FileNotFoundException exFile)
                {
                    erroresArchivos += exFile.Message;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (!string.IsNullOrWhiteSpace(erroresArchivos))
            {
                throw new ApplicationException("Verifique los archivos");
            }

            #endregion

            if (solicitud.Tipo == 2 && solicitud.Cantidad > 10 && solicitud.Precio < 100)
            {
                solicitud.Descuento = 0.5M;
            }
            else
            {
                solicitud.Descuento = 0M;
            }

            switch (solicitud.Tipo)
            {
                case 1:
                    EnviarCorreo(solicitud.Tipo);
                    CalcularSolicitudes(solicitud.Tipo);
                    //Codigo
                    ActivarBanderas(solicitud.Tipo);
                    break;
                case 2:
                    EnviarCorreo(solicitud.Tipo);
                    //Codigo
                    DesactivarBanderas(solicitud.Tipo);
                    break;
                case 3:
                    EnviarCorreo(solicitud.Tipo);
                    //Codigo
                    ActivarBanderas(solicitud.Tipo);
                    break;
                default:
                    EnviarCorreo(solicitud.Tipo);
                    //Codigo
                    CalcularSolicitudes(solicitud.Tipo);
                    DesactivarBanderas(solicitud.Tipo);
                    break;
            }

            var repositorioSolicitud = new RepositorioSolicitud();
            repositorioSolicitud.Guardar(solicitud);
        }
        catch (Exception ex)
        {
            var mensaje = ex.Message + "\n";
            mensaje += ex.Source + "\n";
            mensaje += ex.StackTrace + "\n";
            File.WriteAllText("c:\\logs\\logError.txt", mensaje);
        }
    }

    private void EnviarCorreo(int tipo)
    {
        //Codigo
    }

    private void CalcularSolicitudes(int tipo)
    {
        //Codigo
    }

    private void DesactivarBanderas(int tipo)
    {
        //Codigo
    }

    private void ActivarBanderas(int tipo)
    {
        //Codigo
    }

    #region Validacion de archivo

    private bool ExisteArchivo(string ruta)
    {
        if (!File.Exists(ruta)) throw new FileNotFoundException("El archivo no existe");
        return true;
    }

    //private string ObtenerTipoMimeArchivo(string rutaArchivo)
    //{
    //    var extension = Path.GetExtension(rutaArchivo);

    //    switch (extension)
    //    {
    //        case ".pdf":
    //            return "application/pdf";
    //        case ".txt":
    //            return "text/plain";
    //        case ".xls":
    //            return "application/excel";
    //        case ".doc":
    //            return "application/msword";
    //        default:
    //            return "application/mime";
    //    }
    //}

    private bool ValidarArchivo(string a2)
    {
        var a1 = Path.GetExtension(a2);

        if (a1 == ".pdf" || a1 == ".txt" || a1 == ".xls" || a1 == ".doc")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

}
}
