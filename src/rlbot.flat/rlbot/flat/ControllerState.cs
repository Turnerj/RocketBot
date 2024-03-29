// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

public struct ControllerState : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static ControllerState GetRootAsControllerState(ByteBuffer _bb) { return GetRootAsControllerState(_bb, new ControllerState()); }
  public static ControllerState GetRootAsControllerState(ByteBuffer _bb, ControllerState obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public ControllerState __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  /// -1 for full reverse, 1 for full forward
  public float Throttle { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  /// -1 for full left, 1 for full right
  public float Steer { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  /// -1 for nose down, 1 for nose up
  public float Pitch { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  /// -1 for full left, 1 for full right
  public float Yaw { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  /// -1 for roll left, 1 for roll right
  public float Roll { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  /// true if you want to press the jump button
  public bool Jump { get { int o = __p.__offset(14); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  /// true if you want to press the boost button
  public bool Boost { get { int o = __p.__offset(16); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }
  /// true if you want to press the handbrake button
  public bool Handbrake { get { int o = __p.__offset(18); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static Offset<ControllerState> CreateControllerState(FlatBufferBuilder builder,
      float throttle = 0.0f,
      float steer = 0.0f,
      float pitch = 0.0f,
      float yaw = 0.0f,
      float roll = 0.0f,
      bool jump = false,
      bool boost = false,
      bool handbrake = false) {
    builder.StartObject(8);
    ControllerState.AddRoll(builder, roll);
    ControllerState.AddYaw(builder, yaw);
    ControllerState.AddPitch(builder, pitch);
    ControllerState.AddSteer(builder, steer);
    ControllerState.AddThrottle(builder, throttle);
    ControllerState.AddHandbrake(builder, handbrake);
    ControllerState.AddBoost(builder, boost);
    ControllerState.AddJump(builder, jump);
    return ControllerState.EndControllerState(builder);
  }

  public static void StartControllerState(FlatBufferBuilder builder) { builder.StartObject(8); }
  public static void AddThrottle(FlatBufferBuilder builder, float throttle) { builder.AddFloat(0, throttle, 0.0f); }
  public static void AddSteer(FlatBufferBuilder builder, float steer) { builder.AddFloat(1, steer, 0.0f); }
  public static void AddPitch(FlatBufferBuilder builder, float pitch) { builder.AddFloat(2, pitch, 0.0f); }
  public static void AddYaw(FlatBufferBuilder builder, float yaw) { builder.AddFloat(3, yaw, 0.0f); }
  public static void AddRoll(FlatBufferBuilder builder, float roll) { builder.AddFloat(4, roll, 0.0f); }
  public static void AddJump(FlatBufferBuilder builder, bool jump) { builder.AddBool(5, jump, false); }
  public static void AddBoost(FlatBufferBuilder builder, bool boost) { builder.AddBool(6, boost, false); }
  public static void AddHandbrake(FlatBufferBuilder builder, bool handbrake) { builder.AddBool(7, handbrake, false); }
  public static Offset<ControllerState> EndControllerState(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<ControllerState>(o);
  }
};


}
