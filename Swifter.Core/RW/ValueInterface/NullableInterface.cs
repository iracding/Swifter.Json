﻿using Swifter.Readers;
using Swifter.Writers;

namespace Swifter.RW
{
    internal sealed class NullableInterface<T> : IValueInterface<T?> where T : struct
    {
        public T? ReadValue(IValueReader valueReader)
        {
            return valueReader.ReadNullable<T>();
        }

        public void WriteValue(IValueWriter valueWriter, T? value)
        {
            if (value == null)
            {
                valueWriter.DirectWrite(null);
            }
            else
            {
                ValueInterface<T>.WriteValue(valueWriter, value.Value);
            }
        }
    }
}