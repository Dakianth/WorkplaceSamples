using System;
using System.Threading;

namespace Library
{
    public class ThreadUtils
    {
        private static Exception _exception = null;

        public static string Run(Action action)
        {
            try
            {
                return InternalRun(action);
            }
            catch (Exception ex)
            {
                return $"Erro: {ex.Message}!\nDetalhes: {ex.ToString()}";
            }
        }

        private static string InternalRun(Action action)
        {
            _exception = null;
            var thread = new Thread(SafeRun);
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start(action);
            thread.Join();
            return _exception?.ToString();
        }

        private static void SafeRun(object action)
        {
            try
            {
                var func = action as Action;
                func?.Invoke();
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        public static void ShowError(Exception exception)
        {
            ErrrorReport?.Report(exception);
        }

        public static IProgress<Exception> ErrrorReport { get; set; }
    }
}