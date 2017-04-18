
namespace PlayGround.Common.Sie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public struct DateMonth : IComparable, IFormattable, IComparable<DateMonth>, IEquatable<DateMonth>, IConvertible
    {
        public static DateMonth FromDateTime(DateTime dt)
        {
            return new DateMonth(dt.Year, dt.Month, dt.Day);
        }

        public static DateMonth Now => FromDateTime(DateTime.Now);
        private readonly DateTime _backingDateTime;
        public int Year => _backingDateTime.Year;
        public int Month => _backingDateTime.Month;
        public int Day => 1;
        public DayOfWeek DayOfWeek => _backingDateTime.DayOfWeek;
        public bool IsLastDayOfTheMonth { get; }

        /// <summary>
        /// Return this <see cref="Date"/> as a string in MM/dd/yyyy format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Month:D2}/{Day:D2}/{Year}";
        }

        public DateMonth(DateTime d) : this(d.Year, d.Month)
        {
        }

        public DateMonth(int year, int month, int day=1)
        {
            _backingDateTime = new DateTime(year, month, day);

            var nextDay = _backingDateTime.AddDays(1);
            IsLastDayOfTheMonth = (nextDay.Month != month);
        }

        public DateMonth AddMonths(int months)
        {
            var newDate = _backingDateTime.AddMonths(months);
            return FromDateTime(newDate);
        }

        public DateMonth AddYears(int years)
        {
            var newDate = _backingDateTime.AddYears(years);
            return FromDateTime(newDate);
        }

        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day);
        }

        public int CompareTo(DateMonth other)
        {
            return _backingDateTime.CompareTo(other._backingDateTime);
        }

        public bool Equals(DateMonth other)
        {
            return _backingDateTime.Equals(other._backingDateTime);
        }

        public override bool Equals(object obj)
        {
            if (obj is DateMonth)
            {
                return _backingDateTime.Equals(((DateMonth)obj)._backingDateTime);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _backingDateTime.GetHashCode();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _backingDateTime.ToString(format, formatProvider);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (!(obj is DateMonth))
            {
                throw new ArgumentException(nameof(obj) + " must be a Date", nameof(obj));
            }

            return _backingDateTime.CompareTo(((DateMonth)obj)._backingDateTime);
        }

        public static explicit operator DateTime(DateMonth d)
        {
            return d.ToDateTime();
        }

        public static explicit operator DateMonth(DateTime d)
        {
            return FromDateTime(d);
        }

        public static bool operator ==(DateMonth lhs, DateMonth rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(DateMonth lhs, DateMonth rhs)
        {
            return !lhs.Equals(rhs);
        }

        public static bool operator >(DateMonth lhs, DateMonth rhs)
        {
            return lhs._backingDateTime.Ticks > rhs._backingDateTime.Ticks;
        }

        public static bool operator <(DateMonth lhs, DateMonth rhs)
        {
            return lhs._backingDateTime.Ticks < rhs._backingDateTime.Ticks;
        }

        public static bool operator >=(DateMonth lhs, DateMonth rhs)
        {
            return lhs._backingDateTime.Ticks >= rhs._backingDateTime.Ticks;
        }

        public static bool operator <=(DateMonth lhs, DateMonth rhs)
        {
            return lhs._backingDateTime.Ticks <= rhs._backingDateTime.Ticks;
        }

        TypeCode IConvertible.GetTypeCode()
        {
            return Type.GetTypeCode(typeof(DateTime));
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToBoolean(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToChar(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToSByte(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToByte(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToInt16(provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToUInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToInt32(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToUInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToInt64(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToUInt64(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToSingle(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToDouble(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToDecimal(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToDateTime(provider);
        }

        string IConvertible.ToString(IFormatProvider provider)
        {
            return _backingDateTime.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider)
        {
            return ((IConvertible)_backingDateTime).ToType(conversionType, provider);
        }
    }
}
