using System.Collections.Generic;
using UnityEngine;
using Utils.EditorLogger;

namespace Core.Connection
{
    public class Connector : MonoBehaviour
    {
        private Connectable _currentConnectable;

        public bool HasConnection => _currentConnectable != null;
        
        public Connectable CurrentConnectable => _currentConnectable;

        public void Connect(Connectable connectable)
        {
            
            if (!CheckConnectionPossibility(connectable))
                return;
            
            _currentConnectable = connectable;
            //set
        }

        public void Disconnect()
        {
            
            if (_currentConnectable == null)
            {
                EditorLogger.Log("there is no connectable to disconnect");
                return;
            }
            
            _currentConnectable = null;
        }
        
        private bool CheckConnectionPossibility(Connectable connectable)
        {
            if (connectable == null)
            {
                EditorLogger.Log("connectable is null");
                return false;
            }

            if (connectable == GetComponent<Connectable>())
            {
                EditorLogger.Log("trying to connect to itself");
                return false;
            }
            if (connectable.IsConnected)
            {
                EditorLogger.Log("connectable has already connected to other connector");
                return false;
            }

            if(_currentConnectable != null)
            {
                EditorLogger.Log("this connector already has connectable");
                return false;
            }

            if (_currentConnectable == connectable)
            {
                EditorLogger.Log("cannot connect same connectable");
                return false;
            }

            return true;
        }
    }
}