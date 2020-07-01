namespace LACE.IronPython.Model
{
    public class RaspberryPin
    {
        private bool _lastSignal;

        public bool TrySet(bool signal)
        {
            _lastSignal = signal;

            return _lastSignal = signal;
        }
    }
}
