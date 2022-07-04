using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Data
{
    public class Disposable : IDisposable
    {
        //resource libré 
        private bool disposed;

        private void Dispose(bool disposing)
        {
           
                if (disposing && !disposed)
                {
                    DisposeCore();
                disposed = true;

            }

            // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
            // TODO: affecter aux grands champs une valeur null

        }

        protected virtual void DisposeCore()
        {

        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        ~Disposable()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
