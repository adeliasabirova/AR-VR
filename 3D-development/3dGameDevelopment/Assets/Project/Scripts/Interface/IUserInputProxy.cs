using System;

namespace Project
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}