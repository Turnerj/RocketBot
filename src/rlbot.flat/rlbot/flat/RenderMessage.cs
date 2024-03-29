// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

public struct RenderMessage : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static RenderMessage GetRootAsRenderMessage(ByteBuffer _bb) { return GetRootAsRenderMessage(_bb, new RenderMessage()); }
  public static RenderMessage GetRootAsRenderMessage(ByteBuffer _bb, RenderMessage obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public RenderMessage __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public RenderType RenderType { get { int o = __p.__offset(4); return o != 0 ? (RenderType)__p.bb.GetSbyte(o + __p.bb_pos) : RenderType.DrawLine2D; } }
  public Color? Color { get { int o = __p.__offset(6); return o != 0 ? (Color?)(new Color()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }
  /// For 2d renders this only grabs x and y
  public Vector3? Start { get { int o = __p.__offset(8); return o != 0 ? (Vector3?)(new Vector3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  /// For 2d renders this only grabs x and y
  public Vector3? End { get { int o = __p.__offset(10); return o != 0 ? (Vector3?)(new Vector3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  /// Scales the x size of the text/rectangle, is used for rectangles assuming an initial value of 1
  public int ScaleX { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)1; } }
  /// Scales the y size of the text/rectangle, is used for rectangles assuming an initial value of 1
  public int ScaleY { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)1; } }
  public string Text { get { int o = __p.__offset(16); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
  public ArraySegment<byte>? GetTextBytes() { return __p.__vector_as_arraysegment(16); }
  /// Rectangles can be filled or just outlines.
  public bool IsFilled { get { int o = __p.__offset(18); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static void StartRenderMessage(FlatBufferBuilder builder) { builder.StartObject(8); }
  public static void AddRenderType(FlatBufferBuilder builder, RenderType renderType) { builder.AddSbyte(0, (sbyte)renderType, 1); }
  public static void AddColor(FlatBufferBuilder builder, Offset<Color> colorOffset) { builder.AddOffset(1, colorOffset.Value, 0); }
  public static void AddStart(FlatBufferBuilder builder, Offset<Vector3> startOffset) { builder.AddStruct(2, startOffset.Value, 0); }
  public static void AddEnd(FlatBufferBuilder builder, Offset<Vector3> endOffset) { builder.AddStruct(3, endOffset.Value, 0); }
  public static void AddScaleX(FlatBufferBuilder builder, int scaleX) { builder.AddInt(4, scaleX, 1); }
  public static void AddScaleY(FlatBufferBuilder builder, int scaleY) { builder.AddInt(5, scaleY, 1); }
  public static void AddText(FlatBufferBuilder builder, StringOffset textOffset) { builder.AddOffset(6, textOffset.Value, 0); }
  public static void AddIsFilled(FlatBufferBuilder builder, bool isFilled) { builder.AddBool(7, isFilled, false); }
  public static Offset<RenderMessage> EndRenderMessage(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<RenderMessage>(o);
  }
};


}
