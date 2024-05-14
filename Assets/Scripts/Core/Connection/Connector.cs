using UnityEngine;

namespace Core.Connection
{
    public class Connector
    {
        public Connectable Connectable { get; private set; }
        public bool HasConnection { get; private set; }

        public void Connect(Connectable connectable)
        {
            Connectable = connectable;
            HasConnection = true;
        }

        public void TryDisconnect(bool deleteConnectable = true)
        {
            if (!HasConnection)
                return;
            
            HasConnection = false;
            GameObject.Destroy(Connectable);
            Connectable = null;
        }
    }
}