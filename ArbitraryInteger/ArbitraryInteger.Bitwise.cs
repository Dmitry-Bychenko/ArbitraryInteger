using System;
using System.Numerics;

namespace ArbitraryInteger {

  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// Bitwise operations
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static class Bitwise {
    #region Public

    /// <summary>
    /// Number of bits sets
    /// </summary>
    public static int BitsSet(this BigInteger value) {
      int result = 0;

      for (BigInteger number = BigInteger.Abs(value); number != 0; number /= 2)
        result += (int)(number % 2);

      return result;
    }

    /// <summary>
    /// Set Bit
    /// </summary>
    /// <param name="value">Value to set bit at</param>
    /// <param name="index">Index of bit to set</param>
    public static BigInteger SetBit(this BigInteger value, int index) {
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof(index));

      return value | (BigInteger.One << index);
    }

    /// <summary>
    /// Reset Bit
    /// </summary>
    /// <param name="value">Value to set bit at</param>
    /// <param name="index">Index of bit to reset</param>
    public static BigInteger ResetBit(this BigInteger value, int index) {
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof(index));

      BigInteger mask = BigInteger.One << index;

      return (value | mask) ^ mask;
    }

    /// <summary>
    /// Set Or Reset Bit
    /// </summary>
    /// <param name="value">Value to set bit at</param>
    /// <param name="index">Index of bit to set</param>
    /// <param name="bit">true to set bit, false to reset</param>
    public static BigInteger SetBit(this BigInteger value, int index, bool bit) => bit
      ? SetBit(value, index)
      : ResetBit(value, index);

    /// <summary>
    /// Get Bit
    /// </summary>
    /// <param name="value">Value to Test</param>
    /// <param name="index">index of bit to test</param>
    /// <returns>true, if bit set, false otherwise</returns>
    public static bool GetBit(this BigInteger value, int index) {
      if (index < 0)
        throw new ArgumentOutOfRangeException(nameof(index));

      BigInteger mask = BigInteger.One << index;

      return (value & mask) != 0;
    }

    /// <summary>
    /// Hamming Distance To 
    /// </summary>
    public static int HammingDistanceTo(this BigInteger left, BigInteger right) {
      int result = (left < 0 && right >= 0) || (right < 0 && left >= 0)
        ? 1
        : 0;

      return result + BitsSet(BigInteger.Abs(left) ^ BigInteger.Abs(right));
    }

    /// <summary>
    /// To Gray code
    /// </summary>
    public static BigInteger ToGrayCode(this BigInteger value) {
      BigInteger v = BigInteger.Abs(value);

      return v ^ (v >> 1);
    }

    /// <summary>
    /// From Gray code
    /// </summary>
    public static BigInteger FromGrayCode(this BigInteger value) {
      BigInteger result = BigInteger.Abs(value);

      for (BigInteger v = result >> 1; v > 0; v >>= 1)
        result ^= v;

      return result;
    }

      #endregion Public
    }

}
