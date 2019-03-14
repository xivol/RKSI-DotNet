using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public delegate void ValidationDelegate<T>(Validator<T> sender, EventArgs args);

    class ValidationEventArgs<T> : EventArgs
    {
        public T Value {  get; }
        
        public ValidationEventArgs(T value)
        {
            Value = value;
        }
    }

    class ValidationFailureArgs<T> : ValidationEventArgs<T>
    {
        public string Message { get; }

        public ValidationFailureArgs(T value, string message) :
            base(value)
        {
            Message = message;
        }
    }

    public interface Validator<T>
    {
        void Validate(T value);

        event ValidationDelegate<T> Success;
        event ValidationDelegate<T> Falure;
    }
}
