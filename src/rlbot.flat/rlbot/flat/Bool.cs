// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace rlbot.flat
{

using global::System;
using global::FlatBuffers;

public struct Bool : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Bool __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public bool Val { get { return 0!=__p.bb.Get(__p.bb_pos + 0); } }

  public static Offset<Bool> CreateBool(FlatBufferBuilder builder, bool Val) {
    builder.Prep(1, 1);
    builder.PutBool(Val);
    return new Offset<Bool>(builder.Offset);
  }
};


}
