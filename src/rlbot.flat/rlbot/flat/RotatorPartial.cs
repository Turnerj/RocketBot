// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

public struct RotatorPartial : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static RotatorPartial GetRootAsRotatorPartial(ByteBuffer _bb) { return GetRootAsRotatorPartial(_bb, new RotatorPartial()); }
  public static RotatorPartial GetRootAsRotatorPartial(ByteBuffer _bb, RotatorPartial obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public RotatorPartial __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Float? Pitch { get { int o = __p.__offset(4); return o != 0 ? (Float?)(new Float()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public Float? Yaw { get { int o = __p.__offset(6); return o != 0 ? (Float?)(new Float()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public Float? Roll { get { int o = __p.__offset(8); return o != 0 ? (Float?)(new Float()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartRotatorPartial(FlatBufferBuilder builder) { builder.StartObject(3); }
  public static void AddPitch(FlatBufferBuilder builder, Offset<Float> pitchOffset) { builder.AddStruct(0, pitchOffset.Value, 0); }
  public static void AddYaw(FlatBufferBuilder builder, Offset<Float> yawOffset) { builder.AddStruct(1, yawOffset.Value, 0); }
  public static void AddRoll(FlatBufferBuilder builder, Offset<Float> rollOffset) { builder.AddStruct(2, rollOffset.Value, 0); }
  public static Offset<RotatorPartial> EndRotatorPartial(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<RotatorPartial>(o);
  }
};


}
