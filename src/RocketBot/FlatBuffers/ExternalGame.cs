using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RocketBot.FlatBuffers
{
	internal class ExternalGame
	{
		public const string InterfaceDllPath = "dll/RLBot_Core_Interface.dll";

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool IsInitialized();

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static ByteBufferStruct UpdateLiveDataPacketFlatbuffer();

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static ByteBufferStruct UpdateRigidBodyTickFlatbuffer();

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static ByteBufferStruct UpdateFieldInfoFlatbuffer();

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static ByteBufferStruct GetBallPrediction();

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static int UpdatePlayerInputFlatbuffer(byte[] bytes, int size);

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static int SendQuickChat(byte[] quickChatMessage, int protoSize);

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static int RenderGroup(byte[] renderGroup, int protoSize);

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static void Free(IntPtr ptr);

		[DllImport(InterfaceDllPath, CallingConvention = CallingConvention.Cdecl)]
		public extern static int SetGameState(byte[] bytes, int size);
	}
}
