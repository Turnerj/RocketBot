// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

public struct Color : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Color GetRootAsColor(ByteBuffer _bb) { return GetRootAsColor(_bb, new Color()); }
  public static Color GetRootAsColor(ByteBuffer _bb, Color obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Color __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public byte A { get { int o = __p.__offset(4); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte R { get { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte G { get { int o = __p.__offset(8); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }
  public byte B { get { int o = __p.__offset(10); return o != 0 ? __p.bb.Get(o + __p.bb_pos) : (byte)0; } }

  public static Offset<Color> CreateColor(FlatBufferBuilder builder,
      byte a = 0,
      byte r = 0,
      byte g = 0,
      byte b = 0) {
    builder.StartObject(4);
    Color.AddB(builder, b);
    Color.AddG(builder, g);
    Color.AddR(builder, r);
    Color.AddA(builder, a);
    return Color.EndColor(builder);
  }

  public static void StartColor(FlatBufferBuilder builder) { builder.StartObject(4); }
  public static void AddA(FlatBufferBuilder builder, byte a) { builder.AddByte(0, a, 0); }
  public static void AddR(FlatBufferBuilder builder, byte r) { builder.AddByte(1, r, 0); }
  public static void AddG(FlatBufferBuilder builder, byte g) { builder.AddByte(2, g, 0); }
  public static void AddB(FlatBufferBuilder builder, byte b) { builder.AddByte(3, b, 0); }
  public static Offset<Color> EndColor(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Color>(o);
  }
};


}