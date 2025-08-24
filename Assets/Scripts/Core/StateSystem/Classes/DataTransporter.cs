using System.Collections.Generic;

namespace Core.StateSystem.Classes
{
    public class DataTransporter
    { 
        private readonly Dictionary<string, object> _data;

        public DataTransporter()
        {
            _data = new Dictionary<string, object>();
        }

        public void Set<T>(string key, T value)
        {
            _data[key] = value;
        }
        
        public T Get<T>(string key)
        {
            if (_data.TryGetValue(key, out var value) && value is T typedValue)
                return typedValue;
            
            return default(T);
        }
    }
}