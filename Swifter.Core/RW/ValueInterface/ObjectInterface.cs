﻿using Swifter.Readers;
using Swifter.Tools;
using Swifter.Writers;

namespace Swifter.RW
{
    internal sealed class ObjectInterface : IValueInterface<object>
    {
        public object ReadValue(IValueReader valueReader)
        {
            return valueReader.DirectRead();
        }

        public void WriteValue(IValueWriter valueWriter, object value)
        {
            if (value == null)
            {
                valueWriter.DirectWrite(null);

                return;
            }

            /* 父类引用，子类实例时使用 Type 获取写入器。 */
            if (TypeInfo<object>.Int64TypeHandle != (long)TypeHelper.GetTypeHandle(value))
            {
                ValueInterface.GetInterface(value).Write(valueWriter, value);

                return;
            }

            valueWriter.DirectWrite(value);
        }
    }
}