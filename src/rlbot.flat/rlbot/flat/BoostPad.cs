// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

public struct BoostPad : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static BoostPad GetRootAsBoostPad(ByteBuffer _bb) { return GetRootAsBoostPad(_bb, new BoostPad()); }
  public static BoostPad GetRootAsBoostPad(ByteBuffer _bb, BoostPad obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public BoostPad __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Vector3? Location { get { int o = __p.__offset(4); return o != 0 ? (Vector3?)(new Vector3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public bool IsFullBoost { get { int o = __p.__offset(6); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static void StartBoostPad(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddLocation(FlatBufferBuilder builder, Offset<Vector3> locationOffset) { builder.AddStruct(0, locationOffset.Value, 0); }
  public static void AddIsFullBoost(FlatBufferBuilder builder, bool isFullBoost) { builder.AddBool(1, isFullBoost, false); }
  public static Offset<BoostPad> EndBoostPad(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<BoostPad>(o);
  }
};


}
