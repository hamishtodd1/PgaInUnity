// Written by A generator written by enki, added to by Hamish Todd
/*
    TODO:
        general "distance"?
        
        Update and generalize the projections
        Exp and Log, gosh!
        try your "unity uses e21" thing with e31r
*/
using System;
using System.Text;
using static PGA3D;

using UnityEngine;

public class PGA3D
{
    // just for debug and print output, the basis names
    public static string[] _basis = new[] { "1", "e0", "e1", "e2", "e3", "e01", "e02", "e03", "e12", "e31", "e23", "e021", "e013", "e032", "e123", "e0123" };

    private float[] _mVec = new float[16];

    public PGA3D(float F = 0f, int Idx = 0)
    {
        _mVec[Idx] = F;
    }

    private static PGA3D Motor(float a, float b, float c, float d, float e, float f, float g, float h) {
        PGA3D ret = zeroMv.Clone();
        ret[0] = a; ret[5] = b; ret[6] = c; ret[7] = d; ret[8] = e; ret[9] = f; ret[10] = g; ret[15] = h;
        return ret;
    }

    // private class DualQuat
    // {
    //     public DualQuat()
    // }

    #region Array Access
    public float this[int idx]
    {
        get { return _mVec[idx]; }
        set { _mVec[idx] = value; }
    }
    #endregion

    #region Overloaded Operators

    /// <summary>
    /// PGA3D.Reverse : Ret = ~A
    /// Reverse the order of the basis blades.
    /// </summary>
    public static PGA3D operator ~(PGA3D Mv)
    {
        PGA3D Ret = new PGA3D();
        Ret[ 0] =  Mv[ 0];
        Ret[ 1] =  Mv[ 1];
        Ret[ 2] =  Mv[ 2];
        Ret[ 3] =  Mv[ 3];
        Ret[ 4] =  Mv[ 4];
        Ret[ 5] = -Mv[ 5];
        Ret[ 6] = -Mv[ 6];
        Ret[ 7] = -Mv[ 7];
        Ret[ 8] = -Mv[ 8];
        Ret[ 9] = -Mv[ 9];
        Ret[10] = -Mv[10];
        Ret[11] = -Mv[11];
        Ret[12] = -Mv[12];
        Ret[13] = -Mv[13];
        Ret[14] = -Mv[14];
        Ret[15] =  Mv[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.Dual : Ret = !A
    /// Poincare duality operator.
    /// </summary>
    public static PGA3D operator !(PGA3D A)
    {
        PGA3D Ret = new PGA3D();
        Ret[ 0] =  A[15];
        Ret[ 1] =  A[14];
        Ret[ 2] =  A[13];
        Ret[ 3] =  A[12];
        Ret[ 4] =  A[11];
        Ret[ 5] =  A[10];
        Ret[ 6] =  A[ 9];
        Ret[ 7] =  A[ 8];
        Ret[ 8] =  A[ 7];
        Ret[ 9] =  A[ 6];
        Ret[10] =  A[ 5];
        Ret[11] = -A[ 4];
        Ret[12] = -A[ 3];
        Ret[13] = -A[ 2];
        Ret[14] = -A[ 1];
        Ret[15] =  A[ 0];
        return Ret;
    }

    /// <summary>
    /// PGA3D.Conjugate : Ret = A.Conjugate()
    /// Clifford Conjugation
    /// </summary>
    public PGA3D Conjugate()
    {
        PGA3D Ret = new PGA3D();
        Ret[ 0] = this[ 0];
        Ret[ 1] =-this[ 1];
        Ret[ 2] =-this[ 2];
        Ret[ 3] =-this[ 3];
        Ret[ 4] =-this[ 4];
        Ret[ 5] =-this[ 5];
        Ret[ 6] =-this[ 6];
        Ret[ 7] =-this[ 7];
        Ret[ 8] =-this[ 8];
        Ret[ 9] =-this[ 9];
        Ret[10] =-this[10];
        Ret[11] = this[11];
        Ret[12] = this[12];
        Ret[13] = this[13];
        Ret[14] = this[14];
        Ret[15] = this[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.Mul : Ret = A * B
    /// The geometric product.
    /// </summary>
    public static PGA3D operator *(PGA3D A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = B[0] * A[0] + B[2] * A[2] + B[3] * A[3] + B[4] * A[4] - B[8] * A[8] - B[9] * A[9] - B[10] * A[10] - B[14] * A[14];
        Ret[1] = B[1] * A[0] + B[0] * A[1] - B[5] * A[2] - B[6] * A[3] - B[7] * A[4] + B[2] * A[5] + B[3] * A[6] + B[4] * A[7] + B[11] * A[8] + B[12] * A[9] + B[13] * A[10] + B[8] * A[11] + B[9] * A[12] + B[10] * A[13] + B[15] * A[14] - B[14] * A[15];
        Ret[2] = B[2] * A[0] + B[0] * A[2] - B[8] * A[3] + B[9] * A[4] + B[3] * A[8] - B[4] * A[9] - B[14] * A[10] - B[10] * A[14];
        Ret[3] = B[3] * A[0] + B[8] * A[2] + B[0] * A[3] - B[10] * A[4] - B[2] * A[8] - B[14] * A[9] + B[4] * A[10] - B[9] * A[14];
        Ret[4] = B[4] * A[0] - B[9] * A[2] + B[10] * A[3] + B[0] * A[4] - B[14] * A[8] + B[2] * A[9] - B[3] * A[10] - B[8] * A[14];
        Ret[5] = B[5] * A[0] + B[2] * A[1] - B[1] * A[2] - B[11] * A[3] + B[12] * A[4] + B[0] * A[5] - B[8] * A[6] + B[9] * A[7] + B[6] * A[8] - B[7] * A[9] - B[15] * A[10] - B[3] * A[11] + B[4] * A[12] + B[14] * A[13] - B[13] * A[14] - B[10] * A[15];
        Ret[6] = B[6] * A[0] + B[3] * A[1] + B[11] * A[2] - B[1] * A[3] - B[13] * A[4] + B[8] * A[5] + B[0] * A[6] - B[10] * A[7] - B[5] * A[8] - B[15] * A[9] + B[7] * A[10] + B[2] * A[11] + B[14] * A[12] - B[4] * A[13] - B[12] * A[14] - B[9] * A[15];
        Ret[7] = B[7] * A[0] + B[4] * A[1] - B[12] * A[2] + B[13] * A[3] - B[1] * A[4] - B[9] * A[5] + B[10] * A[6] + B[0] * A[7] - B[15] * A[8] + B[5] * A[9] - B[6] * A[10] + B[14] * A[11] - B[2] * A[12] + B[3] * A[13] - B[11] * A[14] - B[8] * A[15];
        Ret[8] = B[8] * A[0] + B[3] * A[2] - B[2] * A[3] + B[14] * A[4] + B[0] * A[8] + B[10] * A[9] - B[9] * A[10] + B[4] * A[14];
        Ret[9] = B[9] * A[0] - B[4] * A[2] + B[14] * A[3] + B[2] * A[4] - B[10] * A[8] + B[0] * A[9] + B[8] * A[10] + B[3] * A[14];
        Ret[10] = B[10] * A[0] + B[14] * A[2] + B[4] * A[3] - B[3] * A[4] + B[9] * A[8] - B[8] * A[9] + B[0] * A[10] + B[2] * A[14];
        Ret[11] = B[11] * A[0] - B[8] * A[1] + B[6] * A[2] - B[5] * A[3] + B[15] * A[4] - B[3] * A[5] + B[2] * A[6] - B[14] * A[7] - B[1] * A[8] + B[13] * A[9] - B[12] * A[10] + B[0] * A[11] + B[10] * A[12] - B[9] * A[13] + B[7] * A[14] - B[4] * A[15];
        Ret[12] = B[12] * A[0] - B[9] * A[1] - B[7] * A[2] + B[15] * A[3] + B[5] * A[4] + B[4] * A[5] - B[14] * A[6] - B[2] * A[7] - B[13] * A[8] - B[1] * A[9] + B[11] * A[10] - B[10] * A[11] + B[0] * A[12] + B[8] * A[13] + B[6] * A[14] - B[3] * A[15];
        Ret[13] = B[13] * A[0] - B[10] * A[1] + B[15] * A[2] + B[7] * A[3] - B[6] * A[4] - B[14] * A[5] - B[4] * A[6] + B[3] * A[7] + B[12] * A[8] - B[11] * A[9] - B[1] * A[10] + B[9] * A[11] - B[8] * A[12] + B[0] * A[13] + B[5] * A[14] - B[2] * A[15];
        Ret[14] = B[14] * A[0] + B[10] * A[2] + B[9] * A[3] + B[8] * A[4] + B[4] * A[8] + B[3] * A[9] + B[2] * A[10] + B[0] * A[14];
        Ret[15] = B[15] * A[0] + B[14] * A[1] + B[13] * A[2] + B[12] * A[3] + B[11] * A[4] + B[10] * A[5] + B[9] * A[6] + B[8] * A[7] + B[7] * A[8] + B[6] * A[9] + B[5] * A[10] - B[4] * A[11] - B[3] * A[12] - B[2] * A[13] - B[1] * A[14] + B[0] * A[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.Wedge : Ret = A ^ B
    /// The outer product. (MEET)
    /// </summary>
    public static PGA3D operator ^(PGA3D A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = B[0] * A[0];
        Ret[1] = B[1] * A[0] + B[0] * A[1];
        Ret[2] = B[2] * A[0] + B[0] * A[2];
        Ret[3] = B[3] * A[0] + B[0] * A[3];
        Ret[4] = B[4] * A[0] + B[0] * A[4];
        Ret[5] = B[5] * A[0] + B[2] * A[1] - B[1] * A[2] + B[0] * A[5];
        Ret[6] = B[6] * A[0] + B[3] * A[1] - B[1] * A[3] + B[0] * A[6];
        Ret[7] = B[7] * A[0] + B[4] * A[1] - B[1] * A[4] + B[0] * A[7];
        Ret[8] = B[8] * A[0] + B[3] * A[2] - B[2] * A[3] + B[0] * A[8];
        Ret[9] = B[9] * A[0] - B[4] * A[2] + B[2] * A[4] + B[0] * A[9];
        Ret[10] = B[10] * A[0] + B[4] * A[3] - B[3] * A[4] + B[0] * A[10];
        Ret[11] = B[11] * A[0] - B[8] * A[1] + B[6] * A[2] - B[5] * A[3] - B[3] * A[5] + B[2] * A[6] - B[1] * A[8] + B[0] * A[11];
        Ret[12] = B[12] * A[0] - B[9] * A[1] - B[7] * A[2] + B[5] * A[4] + B[4] * A[5] - B[2] * A[7] - B[1] * A[9] + B[0] * A[12];
        Ret[13] = B[13] * A[0] - B[10] * A[1] + B[7] * A[3] - B[6] * A[4] - B[4] * A[6] + B[3] * A[7] - B[1] * A[10] + B[0] * A[13];
        Ret[14] = B[14] * A[0] + B[10] * A[2] + B[9] * A[3] + B[8] * A[4] + B[4] * A[8] + B[3] * A[9] + B[2] * A[10] + B[0] * A[14];
        Ret[15] = B[15] * A[0] + B[14] * A[1] + B[13] * A[2] + B[12] * A[3] + B[11] * A[4] + B[10] * A[5] + B[9] * A[6] + B[8] * A[7] + B[7] * A[8] + B[6] * A[9] + B[5] * A[10] - B[4] * A[11] - B[3] * A[12] - B[2] * A[13] - B[1] * A[14] + B[0] * A[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.Vee : Ret = A & B
    /// The regressive product. (JOIN)
    /// </summary>
    public static PGA3D operator &(PGA3D A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[15] = 1 * (A[15] * B[15]);
        Ret[14] = -1 * (A[14] * -1 * B[15] + A[15] * B[14] * -1);
        Ret[13] = -1 * (A[13] * -1 * B[15] + A[15] * B[13] * -1);
        Ret[12] = -1 * (A[12] * -1 * B[15] + A[15] * B[12] * -1);
        Ret[11] = -1 * (A[11] * -1 * B[15] + A[15] * B[11] * -1);
        Ret[10] = 1 * (A[10] * B[15] + A[13] * -1 * B[14] * -1 - A[14] * -1 * B[13] * -1 + A[15] * B[10]);
        Ret[9] = 1 * (A[9] * B[15] + A[12] * -1 * B[14] * -1 - A[14] * -1 * B[12] * -1 + A[15] * B[9]);
        Ret[8] = 1 * (A[8] * B[15] + A[11] * -1 * B[14] * -1 - A[14] * -1 * B[11] * -1 + A[15] * B[8]);
        Ret[7] = 1 * (A[7] * B[15] + A[12] * -1 * B[13] * -1 - A[13] * -1 * B[12] * -1 + A[15] * B[7]);
        Ret[6] = 1 * (A[6] * B[15] - A[11] * -1 * B[13] * -1 + A[13] * -1 * B[11] * -1 + A[15] * B[6]);
        Ret[5] = 1 * (A[5] * B[15] + A[11] * -1 * B[12] * -1 - A[12] * -1 * B[11] * -1 + A[15] * B[5]);
        Ret[4] = 1 * (A[4] * B[15] - A[7] * B[14] * -1 + A[9] * B[13] * -1 - A[10] * B[12] * -1 - A[12] * -1 * B[10] + A[13] * -1 * B[9] - A[14] * -1 * B[7] + A[15] * B[4]);
        Ret[3] = 1 * (A[3] * B[15] - A[6] * B[14] * -1 - A[8] * B[13] * -1 + A[10] * B[11] * -1 + A[11] * -1 * B[10] - A[13] * -1 * B[8] - A[14] * -1 * B[6] + A[15] * B[3]);
        Ret[2] = 1 * (A[2] * B[15] - A[5] * B[14] * -1 + A[8] * B[12] * -1 - A[9] * B[11] * -1 - A[11] * -1 * B[9] + A[12] * -1 * B[8] - A[14] * -1 * B[5] + A[15] * B[2]);
        Ret[1] = 1 * (A[1] * B[15] + A[5] * B[13] * -1 + A[6] * B[12] * -1 + A[7] * B[11] * -1 + A[11] * -1 * B[7] + A[12] * -1 * B[6] + A[13] * -1 * B[5] + A[15] * B[1]);
        Ret[0] = 1 * (A[0] * B[15] + A[1] * B[14] * -1 + A[2] * B[13] * -1 + A[3] * B[12] * -1 + A[4] * B[11] * -1 + A[5] * B[10] + A[6] * B[9] + A[7] * B[8] + A[8] * B[7] + A[9] * B[6] + A[10] * B[5] - A[11] * -1 * B[4] - A[12] * -1 * B[3] - A[13] * -1 * B[2] - A[14] * -1 * B[1] + A[15] * B[0]);
        return Ret;
    }

    /// <summary>
    /// PGA3D.Dot : Ret = A | B
    /// The inner product.
    /// </summary>
    public static PGA3D operator |(PGA3D A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = B[0] * A[0] + B[2] * A[2] + B[3] * A[3] + B[4] * A[4] - B[8] * A[8] - B[9] * A[9] - B[10] * A[10] - B[14] * A[14];
        Ret[1] = B[1] * A[0] + B[0] * A[1] - B[5] * A[2] - B[6] * A[3] - B[7] * A[4] + B[2] * A[5] + B[3] * A[6] + B[4] * A[7] + B[11] * A[8] + B[12] * A[9] + B[13] * A[10] + B[8] * A[11] + B[9] * A[12] + B[10] * A[13] + B[15] * A[14] - B[14] * A[15];
        Ret[2] = B[2] * A[0] + B[0] * A[2] - B[8] * A[3] + B[9] * A[4] + B[3] * A[8] - B[4] * A[9] - B[14] * A[10] - B[10] * A[14];
        Ret[3] = B[3] * A[0] + B[8] * A[2] + B[0] * A[3] - B[10] * A[4] - B[2] * A[8] - B[14] * A[9] + B[4] * A[10] - B[9] * A[14];
        Ret[4] = B[4] * A[0] - B[9] * A[2] + B[10] * A[3] + B[0] * A[4] - B[14] * A[8] + B[2] * A[9] - B[3] * A[10] - B[8] * A[14];
        Ret[5] = B[5] * A[0] - B[11] * A[3] + B[12] * A[4] + B[0] * A[5] - B[15] * A[10] - B[3] * A[11] + B[4] * A[12] - B[10] * A[15];
        Ret[6] = B[6] * A[0] + B[11] * A[2] - B[13] * A[4] + B[0] * A[6] - B[15] * A[9] + B[2] * A[11] - B[4] * A[13] - B[9] * A[15];
        Ret[7] = B[7] * A[0] - B[12] * A[2] + B[13] * A[3] + B[0] * A[7] - B[15] * A[8] - B[2] * A[12] + B[3] * A[13] - B[8] * A[15];
        Ret[8] = B[8] * A[0] + B[14] * A[4] + B[0] * A[8] + B[4] * A[14];
        Ret[9] = B[9] * A[0] + B[14] * A[3] + B[0] * A[9] + B[3] * A[14];
        Ret[10] = B[10] * A[0] + B[14] * A[2] + B[0] * A[10] + B[2] * A[14];
        Ret[11] = B[11] * A[0] + B[15] * A[4] + B[0] * A[11] - B[4] * A[15];
        Ret[12] = B[12] * A[0] + B[15] * A[3] + B[0] * A[12] - B[3] * A[15];
        Ret[13] = B[13] * A[0] + B[15] * A[2] + B[0] * A[13] - B[2] * A[15];
        Ret[14] = B[14] * A[0] + B[0] * A[14];
        Ret[15] = B[15] * A[0] + B[0] * A[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.Add : Ret = A + B
    /// Multivector addition
    /// </summary>
    public static PGA3D operator +(PGA3D A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A[0] + B[0];
        Ret[1] = A[1] + B[1];
        Ret[2] = A[2] + B[2];
        Ret[3] = A[3] + B[3];
        Ret[4] = A[4] + B[4];
        Ret[5] = A[5] + B[5];
        Ret[6] = A[6] + B[6];
        Ret[7] = A[7] + B[7];
        Ret[8] = A[8] + B[8];
        Ret[9] = A[9] + B[9];
        Ret[10] = A[10] + B[10];
        Ret[11] = A[11] + B[11];
        Ret[12] = A[12] + B[12];
        Ret[13] = A[13] + B[13];
        Ret[14] = A[14] + B[14];
        Ret[15] = A[15] + B[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.Sub : Ret = A - B
    /// Multivector subtraction
    /// </summary>
    public static PGA3D operator -(PGA3D A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A[0] - B[0];
        Ret[1] = A[1] - B[1];
        Ret[2] = A[2] - B[2];
        Ret[3] = A[3] - B[3];
        Ret[4] = A[4] - B[4];
        Ret[5] = A[5] - B[5];
        Ret[6] = A[6] - B[6];
        Ret[7] = A[7] - B[7];
        Ret[8] = A[8] - B[8];
        Ret[9] = A[9] - B[9];
        Ret[10] = A[10] - B[10];
        Ret[11] = A[11] - B[11];
        Ret[12] = A[12] - B[12];
        Ret[13] = A[13] - B[13];
        Ret[14] = A[14] - B[14];
        Ret[15] = A[15] - B[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.smul : Ret = A * B
    /// scalar/multivector multiplication
    /// </summary>
    public static PGA3D operator *(float A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A * B[0];
        Ret[1] = A * B[1];
        Ret[2] = A * B[2];
        Ret[3] = A * B[3];
        Ret[4] = A * B[4];
        Ret[5] = A * B[5];
        Ret[6] = A * B[6];
        Ret[7] = A * B[7];
        Ret[8] = A * B[8];
        Ret[9] = A * B[9];
        Ret[10] = A * B[10];
        Ret[11] = A * B[11];
        Ret[12] = A * B[12];
        Ret[13] = A * B[13];
        Ret[14] = A * B[14];
        Ret[15] = A * B[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.muls : Ret = A * B
    /// multivector/scalar multiplication
    /// </summary>
    public static PGA3D operator *(PGA3D A, float B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A[0] * B;
        Ret[1] = A[1] * B;
        Ret[2] = A[2] * B;
        Ret[3] = A[3] * B;
        Ret[4] = A[4] * B;
        Ret[5] = A[5] * B;
        Ret[6] = A[6] * B;
        Ret[7] = A[7] * B;
        Ret[8] = A[8] * B;
        Ret[9] = A[9] * B;
        Ret[10] = A[10] * B;
        Ret[11] = A[11] * B;
        Ret[12] = A[12] * B;
        Ret[13] = A[13] * B;
        Ret[14] = A[14] * B;
        Ret[15] = A[15] * B;
        return Ret;
    }

    /// <summary>
    /// PGA3D.sadd : Ret = A + B
    /// scalar/multivector addition
    /// </summary>
    public static PGA3D operator +(float A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A + B[0];
        Ret[1] = B[1];
        Ret[2] = B[2];
        Ret[3] = B[3];
        Ret[4] = B[4];
        Ret[5] = B[5];
        Ret[6] = B[6];
        Ret[7] = B[7];
        Ret[8] = B[8];
        Ret[9] = B[9];
        Ret[10] = B[10];
        Ret[11] = B[11];
        Ret[12] = B[12];
        Ret[13] = B[13];
        Ret[14] = B[14];
        Ret[15] = B[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.adds : Ret = A + B
    /// multivector/scalar addition
    /// </summary>
    public static PGA3D operator +(PGA3D A, float B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A[0] + B;
        Ret[1] = A[1];
        Ret[2] = A[2];
        Ret[3] = A[3];
        Ret[4] = A[4];
        Ret[5] = A[5];
        Ret[6] = A[6];
        Ret[7] = A[7];
        Ret[8] = A[8];
        Ret[9] = A[9];
        Ret[10] = A[10];
        Ret[11] = A[11];
        Ret[12] = A[12];
        Ret[13] = A[13];
        Ret[14] = A[14];
        Ret[15] = A[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.ssub : Ret = A - B
    /// scalar/multivector subtraction
    /// </summary>
    public static PGA3D operator -(float A, PGA3D B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A - B[0];
        Ret[1] = -B[1];
        Ret[2] = -B[2];
        Ret[3] = -B[3];
        Ret[4] = -B[4];
        Ret[5] = -B[5];
        Ret[6] = -B[6];
        Ret[7] = -B[7];
        Ret[8] = -B[8];
        Ret[9] = -B[9];
        Ret[10] = -B[10];
        Ret[11] = -B[11];
        Ret[12] = -B[12];
        Ret[13] = -B[13];
        Ret[14] = -B[14];
        Ret[15] = -B[15];
        return Ret;
    }

    /// <summary>
    /// PGA3D.subs : Ret = A - B
    /// multivector/scalar subtraction
    /// </summary>
    public static PGA3D operator -(PGA3D A, float B)
    {
        PGA3D Ret = new PGA3D();
        Ret[0] = A[0] - B;
        Ret[1] = A[1];
        Ret[2] = A[2];
        Ret[3] = A[3];
        Ret[4] = A[4];
        Ret[5] = A[5];
        Ret[6] = A[6];
        Ret[7] = A[7];
        Ret[8] = A[8];
        Ret[9] = A[9];
        Ret[10] = A[10];
        Ret[11] = A[11];
        Ret[12] = A[12];
        Ret[13] = A[13];
        Ret[14] = A[14];
        Ret[15] = A[15];
        return Ret;
    }

    

    public static PGA3D Commutator(PGA3D A, PGA3D B)
    {
        return 0.5f * (A * B - B * A);
    }

    #endregion

    /// <summary>
    /// PGA3D.norm()
    /// Calculate the Euclidean norm. (strict positive).
    /// </summary>
    public float Norm() { 
        return Mathf.Sqrt(Mathf.Abs((this * this.Conjugate())[0]));
    }

    /// <summary>
    /// PGA3D.inorm()
    /// Calculate the Ideal norm. (signed)
    /// </summary>
    public float IdealNorm() { 
        return this[1] != 0.0f ? 
            this[1] : 
            this[15] != 0.0f ? 
                this[15] : 
                (!this).Norm();
    }

    //probably this can be turned into something implicit
    //can do for unity planes too
    public Vector3 PointToVec3() {
        return new Vector3(this[13] / this[14], this[12] / this[14], this[11] / this[14]);
    }

    public Quaternion RotorToQuaternion() {
        // unity uses e21 instead of e12 in its array, proof:
        // Debug.Log("with PGA:");
        // PGA3D PgaDir = Direction(1f, 0f, 0f);
        // PGA3D PgaRotor = (e12 * 0.96f + 0.28f).Normalized();
        // Debug.Log(PgaRotor * PgaDir * ~PgaRotor);

        // Vector3 UnityDir = new Vector3(1f, 0f, 0f);
        // Quaternion UnityQuaternion = (new Quaternion(0f, 0f, 0.96f, 0.28f)).normalized; //because e12 is like z
        // Debug.Log("with Unity:");
        // Debug.Log(UnityQuaternion * UnityDir);

        Quaternion Ret = new Quaternion(-this[10],-this[9],-this[8],this[0]);
        Ret.Normalize();
        return Ret;
    }

    //would be nicer to have the crazy version
    private float InvSqrt(float myFloat){
        return 1f / (myFloat*myFloat);
    }

    /// <summary>
    /// PGA3D.Normalized()
    /// Returns A Normalized (Euclidean) element.
    /// </summary>
    public PGA3D Normalized() {
        PGA3D thisThisReverse = this * (~this);
        if(thisThisReverse[15] != 0f) {
            //proper maths!
            PGA3D StudyInverseSqrt = new PGA3D(0f,0);
            StudyInverseSqrt[ 0] = InvSqrt(thisThisReverse[0]);
            StudyInverseSqrt[15] = thisThisReverse[15] / 2f * StudyInverseSqrt[0] * StudyInverseSqrt[0] * StudyInverseSqrt[0];

            return this * StudyInverseSqrt;
        }
        else {
            float denomSquared = thisThisReverse[0];
            if(denomSquared == 0f) {
                //denom = ideal norm
                PGA3D thisDual = !this;
                denomSquared = (thisDual*(~thisDual))[0];
            }

            return this * InvSqrt(denomSquared);
        }
    }

    public PGA3D SqrtSimpleMotor() { return ((this[0] == -1f ? -1f : 1f) + this ).Normalized(); }
    public PGA3D SqrtGeneralMotor() {
        PGA3D PssPart = e0123 * this[15];
        return (1f + this) * ((1f + this).Normalized() - 0.5f * PssPart);
    }

    public PGA3D Exp(PGA3D B) {
        float l = (B[8]*B[8] + B[9]*B[9] + B[10]*B[10]);
        if (l==0f) {
            return Motor(1f, B[5], B[6], B[7], 0f, 0f, 0f, 0f);
        }
        else {
            float m = (B[0]*B[10] + B[1]*B[9] + B[2]*B[8]), a = Mathf.Sqrt(l), c = Mathf.Cos(a), s = Mathf.Sin(a)/a, t = m/l*(c-s);
            return Motor(c, s*B[0] + t*B[10], s*B[1] + t*B[9], s*B[2] + t*B[8], s*B[8], s*B[9], s*B[10], m*s);
        }
    }

    public PGA3D Log(PGA3D r) {
        if ( r[0] == 1f ) return Motor(0f,r[5],r[6],r[7],0f,0f,0f,0f);
        float a = 1f/(1f - r[0]*r[0]),                 // inv squared length. 
            b = Mathf.Acos(r[0])*Mathf.Sqrt(a),        // rotation scale
            c = a*r[15]*(1f - r[0]*b);                 // translation scale
        return Motor( 0f, c*r[10] + b*r[5], c*r[9] + b*r[6], c*r[8] + b*r[7], b*r[8], b*r[9], b*r[10], 0f );
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

        int Total = HasPart[0] + HasPart[1] + HasPart[2] + HasPart[3] + HasPart[4];
        if( Total > 1 )
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
        PGA3D Ret = new PGA3D();
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
        PGA3D Ret = new PGA3D();
        Ret.Copy(this);
        return Ret;
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
    /// A plane is defined using its homogenous equation ax + by + cz + d = 0
    /// </summary>
    public static PGA3D Plane(float A, float B, float C, float D) { return A * e1 + B * e2 + C * e3 + D * e0; }
    public static PGA3D Plane(Plane pUnity) { return pUnity.normal.x * e1 + pUnity.normal.y * e2 + pUnity.normal.z * e3 + pUnity.distance * e0;}

    /// <summary>
    /// PGA3D. x,y,z)
    /// A point is just A homogeneous point, euclidean coordinates plus the origin
    /// WARNING: Note that there are "Positions" and Directions"
    /// </summary>

    public static PGA3D Position(  float X, float Y, float Z)  { return X * e032 + Y * e013 + Z * e021 + e123; }
    public static PGA3D Direction( float X, float Y, float Z)  { return X * e032 + Y * e013 + Z * e021; }
    public static PGA3D Position(  Vector3 Vec )               { return Vec.x * e032 + Vec.y * e013 + Vec.z * e021 + e123; }
    public static PGA3D Direction( Vector3 Vec )               { return Vec.x * e032 + Vec.y * e013 + Vec.z * e021; }

    public static PGA3D Point(float X, float Y, float Z) { 
        Debug.LogWarning("WARNING: Point has been deprecated and will be removed. You either want to use 'Position' or 'Direction', because that is clearer about what you want. PGA makes a major distinction between positions and directions, and it's important to understand it");
        return e123 + X * e032 + Y * e013 + Z * e021; 
    }
    public static PGA3D Point( Vector3 Vec ) { 
        Debug.LogWarning("WARNING: Point has been deprecated and will be removed. You either want to use 'Position' or 'Direction', because that is clearer about what you want. PGA makes a major distinction between positions and directions, and it's important to understand it");
        return e123 + Vec.x * e032 + Vec.y * e013 + Vec.z * e021 ;
    }
    
    // public static Matrix4x4(PGA3D dq) {
    //     this.m00 = ; this.m01 = ; this.m02 = ; this.m03 = ;
    //     this.m10 = ; this.m11 = ; this.m12 = ; this.m13 = ;
    //     this.m20 = ; this.m21 = ; this.m22 = ; this.m23 = ;
    //     this.m30 = ; this.m31 = ; this.m32 = ; this.m33 = ;
    // }

    /// <summary>
    /// Rotors (euclidean lines) and translators (ideal lines)
    /// </summary>
    public static PGA3D Rotor(float Angle, PGA3D Line) { return (Mathf.Cos(Angle / 2.0f)) + (Mathf.Sin(Angle / 2.0f)) * Line.Normalized(); }
    public static PGA3D Translator(float Dist, PGA3D Line) { return 1.0f + (Dist / 2.0f) * Line; }

    public static PGA3D ProjectOn(PGA3D A, PGA3D B) {
        return (A|B) * (~B);
    }

    public static PGA3D ProjectLineOnPoint(PGA3D L, PGA3D P) {
        Debug.LogWarning("This will be deprecated, just use ProjectOn");
        return ProjectOn(L, P);
    }
    public static PGA3D ProjectPointOnLine(PGA3D P, PGA3D L) {
        Debug.LogWarning("This will be deprecated, just use ProjectOn");
        return ProjectOn(P, L);
    }

    // public static PGA3D Translator(Vector3 translationVector) { return 1.0f + (dist / 2.0f) * line; }
    public static PGA3D Rotor(Quaternion Q) {
        PGA3D Ret = new PGA3D();
        Ret[ 0] = Q.w;
        Ret[10] = Q.x;
        Ret[ 9] = Q.y;
        Ret[ 8] = Q.z;
        return Ret.Normalized();
    }

    public static float DistancePointLine(PGA3D P, PGA3D L) {
        return (P.Normalized() & L.Normalized()).Norm();
    }

    public static float DistancePointPoint(PGA3D P1, PGA3D P2) {
        return (P1.Normalized() & P2.Normalized()).Norm();
    }

    public static float orientedDistancePointPlane(PGA3D Po, PGA3D Pl) {
        return (Po & Pl)[0];
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
            return LineOfMotor.IdealNorm();
        }
    }

    public static PGA3D GexpAxisAngle(PGA3D Axis, float Angle) {
        return Mathf.Cos(Angle * 0.5f) + Mathf.Sin(Angle * 0.5f) * Axis;
    }
    public static PGA3D GexpAxisDistance(PGA3D Axis, float Distance) {
        return 1f + (Distance * 0.5f) * Axis;
    }

    private static int[] evenSubalgebraIndices = new int[8] {0, 5,6,7,8,9,10,15};
    
    //TODO overload something?
    public static PGA3D Sandwich(PGA3D A, PGA3D B) {
        bool flectorAndFlector = true;
        for (int i = 0; i < 8; ++i) {
            if( A[evenSubalgebraIndices[i]] != 0f || B[evenSubalgebraIndices[i]] != 0f )
                flectorAndFlector = false;
        }
        //check through the even subalgebra of both. If all zeroes, throw in a minus sign
        return A * B * (~A) * (flectorAndFlector?-1f:1f);
    }

    public static PGA3D CommonNormalLineLine(PGA3D L1, PGA3D L2 ) {
        return (L1 * L2 - L2 * L1).Normalized(); //commutator but since you normalize it, not much point in halving it
    }

    /// string cast
    public override string ToString()
    {
        var Sb = new StringBuilder();
        var CoefficientIndex = 0;
        for (int i = 0; i < 16; ++i)
            if (_mVec[i] != 0.0f) {
                Sb.Append($"{_mVec[i]}{(i == 0 ? string.Empty : _basis[i])} + ");
                CoefficientIndex++;
            }
        if (CoefficientIndex == 0) Sb.Append("0");
        return Sb.ToString().TrimEnd(' ', '+');
    }
}