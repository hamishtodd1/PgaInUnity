// Written by a generator written by enki, added to by Hamish Todd
using System;
using System.Text;
using static PGA3D;

using UnityEngine;

public class PGA3D
{
    // just for debug and print output, the basis names
    public static string[] _basis = new[] { "1", "e0", "e1", "e2", "e3", "e01", "e02", "e03", "e12", "e31", "e23", "e021", "e013", "e032", "e123", "e0123" };

    private float[] _mVec = new float[16];

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="f"></param>
    /// <param name="idx"></param>
    public PGA3D(float f = 0f, int idx = 0)
    {
        _mVec[idx] = f;
    }

    #region Array Access
    public float this[int idx]
    {
        get { return _mVec[idx]; }
        set { _mVec[idx] = value; }
    }
    #endregion

    #region Overloaded Operators

    /// <summary>
    /// PGA3D.Reverse : res = ~a
    /// Reverse the order of the basis blades.
    /// </summary>
    public static PGA3D operator ~(PGA3D a)
    {
        PGA3D res = new PGA3D();
        res[0] = a[0];
        res[1] = a[1];
        res[2] = a[2];
        res[3] = a[3];
        res[4] = a[4];
        res[5] = -a[5];
        res[6] = -a[6];
        res[7] = -a[7];
        res[8] = -a[8];
        res[9] = -a[9];
        res[10] = -a[10];
        res[11] = -a[11];
        res[12] = -a[12];
        res[13] = -a[13];
        res[14] = -a[14];
        res[15] = a[15];
        return res;
    }

    /// <summary>
    /// PGA3D.Dual : res = !a
    /// Poincare duality operator.
    /// </summary>
    public static PGA3D operator !(PGA3D a)
    {
        PGA3D res = new PGA3D();
        res[0] = a[15];
        res[1] = a[14];
        res[2] = a[13];
        res[3] = a[12];
        res[4] = a[11];
        res[5] = a[10];
        res[6] = a[9];
        res[7] = a[8];
        res[8] = a[7];
        res[9] = a[6];
        res[10] = a[5];
        res[11] = a[4];
        res[12] = a[3];
        res[13] = a[2];
        res[14] = a[1];
        res[15] = a[0];
        return res;
    }

    /// <summary>
    /// PGA3D.Conjugate : res = a.Conjugate()
    /// Clifford Conjugation
    /// </summary>
    public PGA3D Conjugate()
    {
        PGA3D res = new PGA3D();
        res[0] = this[0];
        res[1] = -this[1];
        res[2] = -this[2];
        res[3] = -this[3];
        res[4] = -this[4];
        res[5] = -this[5];
        res[6] = -this[6];
        res[7] = -this[7];
        res[8] = -this[8];
        res[9] = -this[9];
        res[10] = -this[10];
        res[11] = this[11];
        res[12] = this[12];
        res[13] = this[13];
        res[14] = this[14];
        res[15] = this[15];
        return res;
    }

    /// <summary>
    /// PGA3D.Involute : res = a.Involute()
    /// Main involution
    /// </summary>
    public PGA3D Involute()
    {
        PGA3D res = new PGA3D();
        res[0] = this[0];
        res[1] = -this[1];
        res[2] = -this[2];
        res[3] = -this[3];
        res[4] = -this[4];
        res[5] = this[5];
        res[6] = this[6];
        res[7] = this[7];
        res[8] = this[8];
        res[9] = this[9];
        res[10] = this[10];
        res[11] = -this[11];
        res[12] = -this[12];
        res[13] = -this[13];
        res[14] = -this[14];
        res[15] = this[15];
        return res;
    }

    /// <summary>
    /// PGA3D.Mul : res = a * b
    /// The geometric product.
    /// </summary>
    public static PGA3D operator *(PGA3D a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = b[0] * a[0] + b[2] * a[2] + b[3] * a[3] + b[4] * a[4] - b[8] * a[8] - b[9] * a[9] - b[10] * a[10] - b[14] * a[14];
        res[1] = b[1] * a[0] + b[0] * a[1] - b[5] * a[2] - b[6] * a[3] - b[7] * a[4] + b[2] * a[5] + b[3] * a[6] + b[4] * a[7] + b[11] * a[8] + b[12] * a[9] + b[13] * a[10] + b[8] * a[11] + b[9] * a[12] + b[10] * a[13] + b[15] * a[14] - b[14] * a[15];
        res[2] = b[2] * a[0] + b[0] * a[2] - b[8] * a[3] + b[9] * a[4] + b[3] * a[8] - b[4] * a[9] - b[14] * a[10] - b[10] * a[14];
        res[3] = b[3] * a[0] + b[8] * a[2] + b[0] * a[3] - b[10] * a[4] - b[2] * a[8] - b[14] * a[9] + b[4] * a[10] - b[9] * a[14];
        res[4] = b[4] * a[0] - b[9] * a[2] + b[10] * a[3] + b[0] * a[4] - b[14] * a[8] + b[2] * a[9] - b[3] * a[10] - b[8] * a[14];
        res[5] = b[5] * a[0] + b[2] * a[1] - b[1] * a[2] - b[11] * a[3] + b[12] * a[4] + b[0] * a[5] - b[8] * a[6] + b[9] * a[7] + b[6] * a[8] - b[7] * a[9] - b[15] * a[10] - b[3] * a[11] + b[4] * a[12] + b[14] * a[13] - b[13] * a[14] - b[10] * a[15];
        res[6] = b[6] * a[0] + b[3] * a[1] + b[11] * a[2] - b[1] * a[3] - b[13] * a[4] + b[8] * a[5] + b[0] * a[6] - b[10] * a[7] - b[5] * a[8] - b[15] * a[9] + b[7] * a[10] + b[2] * a[11] + b[14] * a[12] - b[4] * a[13] - b[12] * a[14] - b[9] * a[15];
        res[7] = b[7] * a[0] + b[4] * a[1] - b[12] * a[2] + b[13] * a[3] - b[1] * a[4] - b[9] * a[5] + b[10] * a[6] + b[0] * a[7] - b[15] * a[8] + b[5] * a[9] - b[6] * a[10] + b[14] * a[11] - b[2] * a[12] + b[3] * a[13] - b[11] * a[14] - b[8] * a[15];
        res[8] = b[8] * a[0] + b[3] * a[2] - b[2] * a[3] + b[14] * a[4] + b[0] * a[8] + b[10] * a[9] - b[9] * a[10] + b[4] * a[14];
        res[9] = b[9] * a[0] - b[4] * a[2] + b[14] * a[3] + b[2] * a[4] - b[10] * a[8] + b[0] * a[9] + b[8] * a[10] + b[3] * a[14];
        res[10] = b[10] * a[0] + b[14] * a[2] + b[4] * a[3] - b[3] * a[4] + b[9] * a[8] - b[8] * a[9] + b[0] * a[10] + b[2] * a[14];
        res[11] = b[11] * a[0] - b[8] * a[1] + b[6] * a[2] - b[5] * a[3] + b[15] * a[4] - b[3] * a[5] + b[2] * a[6] - b[14] * a[7] - b[1] * a[8] + b[13] * a[9] - b[12] * a[10] + b[0] * a[11] + b[10] * a[12] - b[9] * a[13] + b[7] * a[14] - b[4] * a[15];
        res[12] = b[12] * a[0] - b[9] * a[1] - b[7] * a[2] + b[15] * a[3] + b[5] * a[4] + b[4] * a[5] - b[14] * a[6] - b[2] * a[7] - b[13] * a[8] - b[1] * a[9] + b[11] * a[10] - b[10] * a[11] + b[0] * a[12] + b[8] * a[13] + b[6] * a[14] - b[3] * a[15];
        res[13] = b[13] * a[0] - b[10] * a[1] + b[15] * a[2] + b[7] * a[3] - b[6] * a[4] - b[14] * a[5] - b[4] * a[6] + b[3] * a[7] + b[12] * a[8] - b[11] * a[9] - b[1] * a[10] + b[9] * a[11] - b[8] * a[12] + b[0] * a[13] + b[5] * a[14] - b[2] * a[15];
        res[14] = b[14] * a[0] + b[10] * a[2] + b[9] * a[3] + b[8] * a[4] + b[4] * a[8] + b[3] * a[9] + b[2] * a[10] + b[0] * a[14];
        res[15] = b[15] * a[0] + b[14] * a[1] + b[13] * a[2] + b[12] * a[3] + b[11] * a[4] + b[10] * a[5] + b[9] * a[6] + b[8] * a[7] + b[7] * a[8] + b[6] * a[9] + b[5] * a[10] - b[4] * a[11] - b[3] * a[12] - b[2] * a[13] - b[1] * a[14] + b[0] * a[15];
        return res;
    }

    /// <summary>
    /// PGA3D.Wedge : res = a ^ b
    /// The outer product. (MEET)
    /// </summary>
    public static PGA3D operator ^(PGA3D a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = b[0] * a[0];
        res[1] = b[1] * a[0] + b[0] * a[1];
        res[2] = b[2] * a[0] + b[0] * a[2];
        res[3] = b[3] * a[0] + b[0] * a[3];
        res[4] = b[4] * a[0] + b[0] * a[4];
        res[5] = b[5] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[5];
        res[6] = b[6] * a[0] + b[3] * a[1] - b[1] * a[3] + b[0] * a[6];
        res[7] = b[7] * a[0] + b[4] * a[1] - b[1] * a[4] + b[0] * a[7];
        res[8] = b[8] * a[0] + b[3] * a[2] - b[2] * a[3] + b[0] * a[8];
        res[9] = b[9] * a[0] - b[4] * a[2] + b[2] * a[4] + b[0] * a[9];
        res[10] = b[10] * a[0] + b[4] * a[3] - b[3] * a[4] + b[0] * a[10];
        res[11] = b[11] * a[0] - b[8] * a[1] + b[6] * a[2] - b[5] * a[3] - b[3] * a[5] + b[2] * a[6] - b[1] * a[8] + b[0] * a[11];
        res[12] = b[12] * a[0] - b[9] * a[1] - b[7] * a[2] + b[5] * a[4] + b[4] * a[5] - b[2] * a[7] - b[1] * a[9] + b[0] * a[12];
        res[13] = b[13] * a[0] - b[10] * a[1] + b[7] * a[3] - b[6] * a[4] - b[4] * a[6] + b[3] * a[7] - b[1] * a[10] + b[0] * a[13];
        res[14] = b[14] * a[0] + b[10] * a[2] + b[9] * a[3] + b[8] * a[4] + b[4] * a[8] + b[3] * a[9] + b[2] * a[10] + b[0] * a[14];
        res[15] = b[15] * a[0] + b[14] * a[1] + b[13] * a[2] + b[12] * a[3] + b[11] * a[4] + b[10] * a[5] + b[9] * a[6] + b[8] * a[7] + b[7] * a[8] + b[6] * a[9] + b[5] * a[10] - b[4] * a[11] - b[3] * a[12] - b[2] * a[13] - b[1] * a[14] + b[0] * a[15];
        return res;
    }

    /// <summary>
    /// PGA3D.Vee : res = a & b
    /// The regressive product. (JOIN)
    /// </summary>
    public static PGA3D operator &(PGA3D a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[15] = 1 * (a[15] * b[15]);
        res[14] = -1 * (a[14] * -1 * b[15] + a[15] * b[14] * -1);
        res[13] = -1 * (a[13] * -1 * b[15] + a[15] * b[13] * -1);
        res[12] = -1 * (a[12] * -1 * b[15] + a[15] * b[12] * -1);
        res[11] = -1 * (a[11] * -1 * b[15] + a[15] * b[11] * -1);
        res[10] = 1 * (a[10] * b[15] + a[13] * -1 * b[14] * -1 - a[14] * -1 * b[13] * -1 + a[15] * b[10]);
        res[9] = 1 * (a[9] * b[15] + a[12] * -1 * b[14] * -1 - a[14] * -1 * b[12] * -1 + a[15] * b[9]);
        res[8] = 1 * (a[8] * b[15] + a[11] * -1 * b[14] * -1 - a[14] * -1 * b[11] * -1 + a[15] * b[8]);
        res[7] = 1 * (a[7] * b[15] + a[12] * -1 * b[13] * -1 - a[13] * -1 * b[12] * -1 + a[15] * b[7]);
        res[6] = 1 * (a[6] * b[15] - a[11] * -1 * b[13] * -1 + a[13] * -1 * b[11] * -1 + a[15] * b[6]);
        res[5] = 1 * (a[5] * b[15] + a[11] * -1 * b[12] * -1 - a[12] * -1 * b[11] * -1 + a[15] * b[5]);
        res[4] = 1 * (a[4] * b[15] - a[7] * b[14] * -1 + a[9] * b[13] * -1 - a[10] * b[12] * -1 - a[12] * -1 * b[10] + a[13] * -1 * b[9] - a[14] * -1 * b[7] + a[15] * b[4]);
        res[3] = 1 * (a[3] * b[15] - a[6] * b[14] * -1 - a[8] * b[13] * -1 + a[10] * b[11] * -1 + a[11] * -1 * b[10] - a[13] * -1 * b[8] - a[14] * -1 * b[6] + a[15] * b[3]);
        res[2] = 1 * (a[2] * b[15] - a[5] * b[14] * -1 + a[8] * b[12] * -1 - a[9] * b[11] * -1 - a[11] * -1 * b[9] + a[12] * -1 * b[8] - a[14] * -1 * b[5] + a[15] * b[2]);
        res[1] = 1 * (a[1] * b[15] + a[5] * b[13] * -1 + a[6] * b[12] * -1 + a[7] * b[11] * -1 + a[11] * -1 * b[7] + a[12] * -1 * b[6] + a[13] * -1 * b[5] + a[15] * b[1]);
        res[0] = 1 * (a[0] * b[15] + a[1] * b[14] * -1 + a[2] * b[13] * -1 + a[3] * b[12] * -1 + a[4] * b[11] * -1 + a[5] * b[10] + a[6] * b[9] + a[7] * b[8] + a[8] * b[7] + a[9] * b[6] + a[10] * b[5] - a[11] * -1 * b[4] - a[12] * -1 * b[3] - a[13] * -1 * b[2] - a[14] * -1 * b[1] + a[15] * b[0]);
        return res;
    }

    /// <summary>
    /// PGA3D.Dot : res = a | b
    /// The inner product.
    /// </summary>
    public static PGA3D operator |(PGA3D a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = b[0] * a[0] + b[2] * a[2] + b[3] * a[3] + b[4] * a[4] - b[8] * a[8] - b[9] * a[9] - b[10] * a[10] - b[14] * a[14];
        res[1] = b[1] * a[0] + b[0] * a[1] - b[5] * a[2] - b[6] * a[3] - b[7] * a[4] + b[2] * a[5] + b[3] * a[6] + b[4] * a[7] + b[11] * a[8] + b[12] * a[9] + b[13] * a[10] + b[8] * a[11] + b[9] * a[12] + b[10] * a[13] + b[15] * a[14] - b[14] * a[15];
        res[2] = b[2] * a[0] + b[0] * a[2] - b[8] * a[3] + b[9] * a[4] + b[3] * a[8] - b[4] * a[9] - b[14] * a[10] - b[10] * a[14];
        res[3] = b[3] * a[0] + b[8] * a[2] + b[0] * a[3] - b[10] * a[4] - b[2] * a[8] - b[14] * a[9] + b[4] * a[10] - b[9] * a[14];
        res[4] = b[4] * a[0] - b[9] * a[2] + b[10] * a[3] + b[0] * a[4] - b[14] * a[8] + b[2] * a[9] - b[3] * a[10] - b[8] * a[14];
        res[5] = b[5] * a[0] - b[11] * a[3] + b[12] * a[4] + b[0] * a[5] - b[15] * a[10] - b[3] * a[11] + b[4] * a[12] - b[10] * a[15];
        res[6] = b[6] * a[0] + b[11] * a[2] - b[13] * a[4] + b[0] * a[6] - b[15] * a[9] + b[2] * a[11] - b[4] * a[13] - b[9] * a[15];
        res[7] = b[7] * a[0] - b[12] * a[2] + b[13] * a[3] + b[0] * a[7] - b[15] * a[8] - b[2] * a[12] + b[3] * a[13] - b[8] * a[15];
        res[8] = b[8] * a[0] + b[14] * a[4] + b[0] * a[8] + b[4] * a[14];
        res[9] = b[9] * a[0] + b[14] * a[3] + b[0] * a[9] + b[3] * a[14];
        res[10] = b[10] * a[0] + b[14] * a[2] + b[0] * a[10] + b[2] * a[14];
        res[11] = b[11] * a[0] + b[15] * a[4] + b[0] * a[11] - b[4] * a[15];
        res[12] = b[12] * a[0] + b[15] * a[3] + b[0] * a[12] - b[3] * a[15];
        res[13] = b[13] * a[0] + b[15] * a[2] + b[0] * a[13] - b[2] * a[15];
        res[14] = b[14] * a[0] + b[0] * a[14];
        res[15] = b[15] * a[0] + b[0] * a[15];
        return res;
    }

    /// <summary>
    /// PGA3D.Add : res = a + b
    /// Multivector addition
    /// </summary>
    public static PGA3D operator +(PGA3D a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = a[0] + b[0];
        res[1] = a[1] + b[1];
        res[2] = a[2] + b[2];
        res[3] = a[3] + b[3];
        res[4] = a[4] + b[4];
        res[5] = a[5] + b[5];
        res[6] = a[6] + b[6];
        res[7] = a[7] + b[7];
        res[8] = a[8] + b[8];
        res[9] = a[9] + b[9];
        res[10] = a[10] + b[10];
        res[11] = a[11] + b[11];
        res[12] = a[12] + b[12];
        res[13] = a[13] + b[13];
        res[14] = a[14] + b[14];
        res[15] = a[15] + b[15];
        return res;
    }

    /// <summary>
    /// PGA3D.Sub : res = a - b
    /// Multivector subtraction
    /// </summary>
    public static PGA3D operator -(PGA3D a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = a[0] - b[0];
        res[1] = a[1] - b[1];
        res[2] = a[2] - b[2];
        res[3] = a[3] - b[3];
        res[4] = a[4] - b[4];
        res[5] = a[5] - b[5];
        res[6] = a[6] - b[6];
        res[7] = a[7] - b[7];
        res[8] = a[8] - b[8];
        res[9] = a[9] - b[9];
        res[10] = a[10] - b[10];
        res[11] = a[11] - b[11];
        res[12] = a[12] - b[12];
        res[13] = a[13] - b[13];
        res[14] = a[14] - b[14];
        res[15] = a[15] - b[15];
        return res;
    }

    /// <summary>
    /// PGA3D.smul : res = a * b
    /// scalar/multivector multiplication
    /// </summary>
    public static PGA3D operator *(float a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = a * b[0];
        res[1] = a * b[1];
        res[2] = a * b[2];
        res[3] = a * b[3];
        res[4] = a * b[4];
        res[5] = a * b[5];
        res[6] = a * b[6];
        res[7] = a * b[7];
        res[8] = a * b[8];
        res[9] = a * b[9];
        res[10] = a * b[10];
        res[11] = a * b[11];
        res[12] = a * b[12];
        res[13] = a * b[13];
        res[14] = a * b[14];
        res[15] = a * b[15];
        return res;
    }

    /// <summary>
    /// PGA3D.muls : res = a * b
    /// multivector/scalar multiplication
    /// </summary>
    public static PGA3D operator *(PGA3D a, float b)
    {
        PGA3D res = new PGA3D();
        res[0] = a[0] * b;
        res[1] = a[1] * b;
        res[2] = a[2] * b;
        res[3] = a[3] * b;
        res[4] = a[4] * b;
        res[5] = a[5] * b;
        res[6] = a[6] * b;
        res[7] = a[7] * b;
        res[8] = a[8] * b;
        res[9] = a[9] * b;
        res[10] = a[10] * b;
        res[11] = a[11] * b;
        res[12] = a[12] * b;
        res[13] = a[13] * b;
        res[14] = a[14] * b;
        res[15] = a[15] * b;
        return res;
    }

    /// <summary>
    /// PGA3D.sadd : res = a + b
    /// scalar/multivector addition
    /// </summary>
    public static PGA3D operator +(float a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = a + b[0];
        res[1] = b[1];
        res[2] = b[2];
        res[3] = b[3];
        res[4] = b[4];
        res[5] = b[5];
        res[6] = b[6];
        res[7] = b[7];
        res[8] = b[8];
        res[9] = b[9];
        res[10] = b[10];
        res[11] = b[11];
        res[12] = b[12];
        res[13] = b[13];
        res[14] = b[14];
        res[15] = b[15];
        return res;
    }

    /// <summary>
    /// PGA3D.adds : res = a + b
    /// multivector/scalar addition
    /// </summary>
    public static PGA3D operator +(PGA3D a, float b)
    {
        PGA3D res = new PGA3D();
        res[0] = a[0] + b;
        res[1] = a[1];
        res[2] = a[2];
        res[3] = a[3];
        res[4] = a[4];
        res[5] = a[5];
        res[6] = a[6];
        res[7] = a[7];
        res[8] = a[8];
        res[9] = a[9];
        res[10] = a[10];
        res[11] = a[11];
        res[12] = a[12];
        res[13] = a[13];
        res[14] = a[14];
        res[15] = a[15];
        return res;
    }

    /// <summary>
    /// PGA3D.ssub : res = a - b
    /// scalar/multivector subtraction
    /// </summary>
    public static PGA3D operator -(float a, PGA3D b)
    {
        PGA3D res = new PGA3D();
        res[0] = a - b[0];
        res[1] = -b[1];
        res[2] = -b[2];
        res[3] = -b[3];
        res[4] = -b[4];
        res[5] = -b[5];
        res[6] = -b[6];
        res[7] = -b[7];
        res[8] = -b[8];
        res[9] = -b[9];
        res[10] = -b[10];
        res[11] = -b[11];
        res[12] = -b[12];
        res[13] = -b[13];
        res[14] = -b[14];
        res[15] = -b[15];
        return res;
    }

    /// <summary>
    /// PGA3D.subs : res = a - b
    /// multivector/scalar subtraction
    /// </summary>
    public static PGA3D operator -(PGA3D a, float b)
    {
        PGA3D res = new PGA3D();
        res[0] = a[0] - b;
        res[1] = a[1];
        res[2] = a[2];
        res[3] = a[3];
        res[4] = a[4];
        res[5] = a[5];
        res[6] = a[6];
        res[7] = a[7];
        res[8] = a[8];
        res[9] = a[9];
        res[10] = a[10];
        res[11] = a[11];
        res[12] = a[12];
        res[13] = a[13];
        res[14] = a[14];
        res[15] = a[15];
        return res;
    }

    public static PGA3D Commutator(PGA3D a, PGA3D b)
    {
        return 0.5f * (a * b - b * a);
    }

    #endregion

    /// <summary>
    /// PGA3D.norm()
    /// Calculate the Euclidean norm. (strict positive).
    /// </summary>
    public float norm() { 
        return Mathf.Sqrt(Mathf.Abs((this * this.Conjugate())[0]));
    }

    /// <summary>
    /// PGA3D.inorm()
    /// Calculate the Ideal norm. (signed)
    /// </summary>
    public float inorm() { 
        return this[1] != 0.0f ? 
            this[1] : 
            this[15] != 0.0f ? 
                this[15] : 
                (!this).norm();
    }

    //probably this can be turned into something implicit
    //can do for unity planes too
    public Vector3 pointToVec3() {
        return new Vector3(this[13] / this[14], this[12] / this[14], this[11] / this[14]);
    }

    public Quaternion RotorToQuaternion() {
        //unity uses e21 instead of e12 in its array, proof:
        // PGA3D PgaDir = direction(1f, 0f, 0f);
        // PGA3D PgaRotor = (e12 + 1f).Normalized();
        // Debug.Log("with PGA:");
        // Debug.Log(PgaRotor * PgaDir * ~PgaRotor);

        // Vector3 UnityDir = new Vector3(1f, 0f, 0f);
        // Quaternion UnityQuaternion = (new Quaternion(0f, 0f, 1f, 1f)).normalized;
        // Debug.Log("with Unity:");
        // Debug.Log(UnityQuaternion * UnityDir);

        Quaternion ret = new Quaternion(-this[10],-this[9],-this[8],this[0]);
        ret.Normalize();
        return ret;
    }

    /// <summary>
    /// PGA3D.Normalized()
    /// Returns a Normalized (Euclidean) element.
    /// </summary>
    public PGA3D Normalized() {
        float normToUse = norm();
        if(normToUse == 0f)
            normToUse = inorm();
        return this * (1f / normToUse);
    }

    public PGA3D SqrtSimpleMotor() { return ((this[0] == -1f ? -1f : 1f) + this ).Normalized(); }
    public PGA3D SqrtGeneralMotor() {
        PGA3D PssPart = e0123 * this[15];
        return (1f + this) * ((1f + this).Normalized() - 0.5f * PssPart);
    }

    public int Grade() {
        int[] HasPart = new int[5];
        HasPart[0] = Mathf.Abs(this[ 0]) > 0.00001f ? 1 : 0;
        HasPart[1] = Mathf.Abs(this[ 1]) > 0.00001f || Mathf.Abs(this[ 2]) > 0.00001f || Mathf.Abs(this[ 3]) > 0.00001f || Mathf.Abs(this[ 4]) > 0.00001f ? 1 : 0;
        HasPart[2] = 
            Mathf.Abs(this[ 5]) > 0.00001f || Mathf.Abs(this[ 6]) > 0.00001f || Mathf.Abs(this[ 7]) > 0.00001f || 
            Mathf.Abs(this[ 8]) > 0.00001f || Mathf.Abs(this[ 9]) > 0.00001f || Mathf.Abs(this[10]) > 0.00001f ? 1 : 0;
        HasPart[3] = Mathf.Abs(this[11]) > 0.00001f || Mathf.Abs(this[12]) > 0.00001f || Mathf.Abs(this[13]) > 0.00001f || Mathf.Abs(this[14]) > 0.00001f ? 1 : 0;
        HasPart[4] = Mathf.Abs(this[15]) > 0.00001f ? 1 : 0;

        int total = HasPart[0] + HasPart[1] + HasPart[2] + HasPart[3] + HasPart[4];
        if( total > 1 )
            return -1;
        else {
            for(int i = 0; i < 5; ++i) {
                if(HasPart[i] != 0)
                    return i;
            }
            
            return -1;
        }

        //probably -mv not really similar to mv. -1 goes along with .5 and 2 and other numbers as things to multiply by
    }

    private static bool[,] IsInGrade = new bool[5,16] {
        { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, },
        {false,  true,  true,  true,  true, false, false, false, false, false, false, false, false, false, false, false, },
        {false, false, false, false, false,  true,  true,  true,  true,  true,  true, false, false, false, false, false, },
        {false, false, false, false, false, false, false, false, false, false, false,  true,  true,  true,  true, false, },
        {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false,  true }
    };
    public PGA3D SelectGrade(int Grade) {
        PGA3D Ret = this.Clone();
        for(int i = 0; i < 16; ++i) {
            if ( IsInGrade[Grade, i] == false)
                Ret[i] = 0f;
        }

        return Ret;
    }

    public void Copy(PGA3D Source) {
        PGA3D res = new PGA3D();
        this[0] = Source[0];
        this[1] = Source[1];
        this[2] = Source[2];
        this[3] = Source[3];
        this[4] = Source[4];
        this[5] = Source[5];
        this[6] = Source[6];
        this[7] = Source[7];
        this[8] = Source[8];
        this[9] = Source[9];
        this[10] = Source[10];
        this[11] = Source[11];
        this[12] = Source[12];
        this[13] = Source[13];
        this[14] = Source[14];
        this[15] = Source[15];
    }

    public PGA3D Clone() {
        PGA3D res = new PGA3D();
        res.Copy(this);
        return res;
    }

    public bool IsZero() {
        bool Ret = true;
        for(int i = 0; i < 16; ++i)
            if(this[i] != 0f)
                Ret = false;
        return Ret;
    }

    // PGA is plane based. Vectors are planes. (think linear functionals)
    public static PGA3D e0 = new PGA3D(1f, 1);
    public static PGA3D e1 = new PGA3D(1f, 2);
    public static PGA3D e2 = new PGA3D(1f, 3);
    public static PGA3D e3 = new PGA3D(1f, 4);

    // PGA lines are bivectors.
    public static PGA3D e01 = e0 ^ e1;
    public static PGA3D e02 = e0 ^ e2;
    public static PGA3D e03 = e0 ^ e3;
    public static PGA3D e12 = e1 ^ e2;
    public static PGA3D e31 = e3 ^ e1;
    public static PGA3D e23 = e2 ^ e3;

    public static PGA3D zeroMv = new PGA3D(0f,0);

    // PGA points are trivectors.
    public static PGA3D e123 = e1 ^ e2 ^ e3; // the origin
    public static PGA3D e032 = e0 ^ e3 ^ e2;
    public static PGA3D e013 = e0 ^ e1 ^ e3;
    public static PGA3D e021 = e0 ^ e2 ^ e1;


    public static PGA3D e0123 = e0 * e123;

    /// <summary>
    /// PGA3D.plane(a,b,c,d)
    /// A plane is defined using its homogenous equation ax + by + cz + d = 0
    /// </summary>
    public static PGA3D plane(float a, float b, float c, float d) { return a * e1 + b * e2 + c * e3 + d * e0; }

    /// <summary>
    /// PGA3D. x,y,z)
    /// A point is just a homogeneous point, euclidean coordinates plus the origin
    /// </summary>
    public static PGA3D point(float x, float y, float z) { return e123 + x * e032 + y * e013 + z * e021; }
    public static PGA3D point( Vector3 vec ) { return (e123 + vec.x * e032 + vec.y * e013 + vec.z * e021).Normalized(); }
    public static PGA3D direction( Vector3 vec ) { return (vec.x * e032 + vec.y * e013 + vec.z * e021).Normalized(); }
    public static PGA3D direction(float x, float y, float z) { return x * e032 + y * e013 + z * e021; }

    /// <summary>
    /// Rotors (euclidean lines) and translators (ideal lines)
    /// </summary>
    public static PGA3D rotor(float angle, PGA3D line) { return (Mathf.Cos(angle / 2.0f)) + (Mathf.Sin(angle / 2.0f)) * line.Normalized(); }
    public static PGA3D translator(float dist, PGA3D line) { return 1.0f + (dist / 2.0f) * line; }

    public static PGA3D ProjectLineOnPoint(PGA3D l, PGA3D p) {
        return (l|p) * p;
    }
    public static PGA3D ProjectPointOnLine(PGA3D p, PGA3D l) {
        return (l|p) * l;
    }

    // public static PGA3D translator(Vector3 translationVector) { return 1.0f + (dist / 2.0f) * line; }
    public static PGA3D rotor(Quaternion q) {
        PGA3D ret = new PGA3D();
        ret[ 0] = q.w;
        ret[10] = q.x;
        ret[ 9] = q.y;
        ret[ 8] = q.z;
        return ret.Normalized();
    }

    public static float DistancePointLine(PGA3D p, PGA3D l) {
        return (p.Normalized() & l.Normalized()).norm();
    }

    public static float DistancePointPoint(PGA3D p1, PGA3D p2) {
        return (p1.Normalized() & p2.Normalized()).norm();
    }

    public static float orientedDistancePointPlane(PGA3D po, PGA3D pl) {
        return (po & pl)[0];
    }

    public static float AngleLineLine(PGA3D L1, PGA3D L2) {
        //remarkably this can go up to pi, defying intuition
        return Mathf.Acos((L1 | L2)[0]);
    }
    
    public static float DistanceLineLine(PGA3D L1, PGA3D L2) {
        //They'd better be Normalized
        float Angle = AngleLineLine(L1, L2);

        //don't even know if this works
        if(Angle != 0f) {
            float SomeBizarreScalar = (L1 & L2)[0];

            //It has orientation information so you can get that without the abs
            return Mathf.Abs( (1f / Mathf.Sin(Angle)) * SomeBizarreScalar );
        }
        else {
            PGA3D LineOfMotor = (L1 * L2).Normalized().SelectGrade(2);
            return LineOfMotor.inorm();
        }
    }

    public static PGA3D GexpAxisAngle(PGA3D Axis, float Angle) {
        return Mathf.Cos(Angle * 0.5f) + Mathf.Sin(Angle * 0.5f) * Axis;
    }
    public static PGA3D GexpAxisDistance(PGA3D Axis, float Distance) {
        return 1f + (Distance * 0.5f) * Axis;
    }

    // public static float GeneralDifference(PGA3D mv1, PGA3D mv2) {
    //     if(mv1.Grade() !== mv2.Grade() || mv1.Grade() == -1)
    //         return 999999f;

    //     if(mv1.Grade() == 0)
    //         return Mathf.abs(mv1[0] - mv2[0]);
    //     if(mv1.Grade() == 3 && mv1[14] == mv2[14]) // assuming Normalized
    //         return Mathf.Sqrt(
    //             Sq(mv1[13] - mv2[13]) +
    //             Sq(mv1[12] - mv2[12]) +
    //             Sq(mv1[11] - mv2[11]) );
    // }

    public static PGA3D CommonNormalLineLine(PGA3D L1, PGA3D L2 ) {
        return (L1 * L2 - L2 * L1).Normalized(); //commutator but since you normalize it, not much point in halving it
    }

    /// string cast
    public override string ToString()
    {
        var sb = new StringBuilder();
        var n = 0;
        for (int i = 0; i < 16; ++i)
            if (_mVec[i] != 0.0f) {
                sb.Append($"{_mVec[i]}{(i == 0 ? string.Empty : _basis[i])} + ");
                n++;
            }
        if (n == 0) sb.Append("0");
        return sb.ToString().TrimEnd(' ', '+');
    }

    public enum PgaOperation {
        GeometricProduct,
        Join,
        Inner,
        Outer,
        Sandwich
    };
    public static PGA3D ApplyOperation(PGA3D Mv1, PGA3D Mv2, PgaOperation pgaOperation) {
        switch(pgaOperation ) {
            case PgaOperation.GeometricProduct:
                return Mv1 * Mv2;
                break;
            case PgaOperation.Join:
                return Mv1 & Mv2;
                break;
            case PgaOperation.Outer:
                return Mv1 ^ Mv2;
                break;
            case PgaOperation.Inner:
                return Mv1 | Mv2;
                break;
            case PgaOperation.Sandwich:
                return Mv1 * Mv2 * ~Mv1;
                break;
            default:
                return new PGA3D();
        }
    }
}
// namespace PGA
// {
// }