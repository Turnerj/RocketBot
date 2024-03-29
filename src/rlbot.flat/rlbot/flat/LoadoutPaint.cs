// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

/// Specification for 'painted' items. See https://github.com/RLBot/RLBot/wiki/Bot-Customization
public struct LoadoutPaint : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static LoadoutPaint GetRootAsLoadoutPaint(ByteBuffer _bb) { return GetRootAsLoadoutPaint(_bb, new LoadoutPaint()); }
  public static LoadoutPaint GetRootAsLoadoutPaint(ByteBuffer _bb, LoadoutPaint obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public LoadoutPaint __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int CarPaintId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int DecalPaintId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int WheelsPaintId { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int BoostPaintId { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int AntennaPaintId { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int HatPaintId { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int TrailsPaintId { get { int o = __p.__offset(16); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int GoalExplosionPaintId { get { int o = __p.__offset(18); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<LoadoutPaint> CreateLoadoutPaint(FlatBufferBuilder builder,
      int carPaintId = 0,
      int decalPaintId = 0,
      int wheelsPaintId = 0,
      int boostPaintId = 0,
      int antennaPaintId = 0,
      int hatPaintId = 0,
      int trailsPaintId = 0,
      int goalExplosionPaintId = 0) {
    builder.StartObject(8);
    LoadoutPaint.AddGoalExplosionPaintId(builder, goalExplosionPaintId);
    LoadoutPaint.AddTrailsPaintId(builder, trailsPaintId);
    LoadoutPaint.AddHatPaintId(builder, hatPaintId);
    LoadoutPaint.AddAntennaPaintId(builder, antennaPaintId);
    LoadoutPaint.AddBoostPaintId(builder, boostPaintId);
    LoadoutPaint.AddWheelsPaintId(builder, wheelsPaintId);
    LoadoutPaint.AddDecalPaintId(builder, decalPaintId);
    LoadoutPaint.AddCarPaintId(builder, carPaintId);
    return LoadoutPaint.EndLoadoutPaint(builder);
  }

  public static void StartLoadoutPaint(FlatBufferBuilder builder) { builder.StartObject(8); }
  public static void AddCarPaintId(FlatBufferBuilder builder, int carPaintId) { builder.AddInt(0, carPaintId, 0); }
  public static void AddDecalPaintId(FlatBufferBuilder builder, int decalPaintId) { builder.AddInt(1, decalPaintId, 0); }
  public static void AddWheelsPaintId(FlatBufferBuilder builder, int wheelsPaintId) { builder.AddInt(2, wheelsPaintId, 0); }
  public static void AddBoostPaintId(FlatBufferBuilder builder, int boostPaintId) { builder.AddInt(3, boostPaintId, 0); }
  public static void AddAntennaPaintId(FlatBufferBuilder builder, int antennaPaintId) { builder.AddInt(4, antennaPaintId, 0); }
  public static void AddHatPaintId(FlatBufferBuilder builder, int hatPaintId) { builder.AddInt(5, hatPaintId, 0); }
  public static void AddTrailsPaintId(FlatBufferBuilder builder, int trailsPaintId) { builder.AddInt(6, trailsPaintId, 0); }
  public static void AddGoalExplosionPaintId(FlatBufferBuilder builder, int goalExplosionPaintId) { builder.AddInt(7, goalExplosionPaintId, 0); }
  public static Offset<LoadoutPaint> EndLoadoutPaint(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<LoadoutPaint>(o);
  }
};


}
