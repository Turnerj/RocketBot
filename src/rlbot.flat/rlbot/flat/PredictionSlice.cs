// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

public struct PredictionSlice : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static PredictionSlice GetRootAsPredictionSlice(ByteBuffer _bb) { return GetRootAsPredictionSlice(_bb, new PredictionSlice()); }
  public static PredictionSlice GetRootAsPredictionSlice(ByteBuffer _bb, PredictionSlice obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public PredictionSlice __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  /// The moment in game time that this prediction corresponds to.
  /// This corresponds to 'secondsElapsed' in the GameInfo table.
  public float GameSeconds { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetFloat(o + __p.bb_pos) : (float)0.0f; } }
  /// The predicted location and motion of the object.
  public Physics? Physics { get { int o = __p.__offset(6); return o != 0 ? (Physics?)(new Physics()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<PredictionSlice> CreatePredictionSlice(FlatBufferBuilder builder,
      float gameSeconds = 0.0f,
      Offset<Physics> physicsOffset = default(Offset<Physics>)) {
    builder.StartObject(2);
    PredictionSlice.AddPhysics(builder, physicsOffset);
    PredictionSlice.AddGameSeconds(builder, gameSeconds);
    return PredictionSlice.EndPredictionSlice(builder);
  }

  public static void StartPredictionSlice(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddGameSeconds(FlatBufferBuilder builder, float gameSeconds) { builder.AddFloat(0, gameSeconds, 0.0f); }
  public static void AddPhysics(FlatBufferBuilder builder, Offset<Physics> physicsOffset) { builder.AddOffset(1, physicsOffset.Value, 0); }
  public static Offset<PredictionSlice> EndPredictionSlice(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<PredictionSlice>(o);
  }
};


}