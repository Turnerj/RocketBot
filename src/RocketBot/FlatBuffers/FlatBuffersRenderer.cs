using FlatBuffers;
using rlbot.flat;
using RocketBot.FlatBuffers.Extensions;
using RocketBot.Rendering.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketBot.FlatBuffers
{
	public class FlatBuffersRenderer
	{
		public FlatBufferBuilder BuildRender(int index, IEnumerable<IRenderCommand> renderCommands)
		{
			var builder = new FlatBufferBuilder(100);
			var messages = new List<Offset<RenderMessage>>();

			foreach (var command in renderCommands)
			{
				if (command is ClearScreenCommand)
				{
					//NOOP
					break;
				}
				else if (command is Line2D3DCommand line2d3d)
				{
					Line2D3D(line2d3d, builder, messages);
				}
				else if (command is Line2DCommand line2d)
				{
					Line2D(line2d, builder, messages);
				}
				else if (command is Line3DCommand line3d)
				{
					Line3D(line3d, builder, messages);
				}
				else if (command is PolyLine2DCommand polyLine2d)
				{
					PolyLine2D(polyLine2d, builder, messages);
				}
				else if (command is PolyLine3DCommand polyLine3d)
				{
					PolyLine3D(polyLine3d, builder, messages);
				}
				else if (command is Rectangle2DCommand rectangle2d)
				{
					Rectangle2D(rectangle2d, builder, messages);
				}
				else if (command is Rectangle3DCommand rectangle3d)
				{
					Rectangle3D(rectangle3d, builder, messages);
				}
				else if (command is String2DCommand string2d)
				{
					String2D(string2d, builder, messages);
				}
				else if (command is String3DCommand string3d)
				{
					String3D(string3d, builder, messages);
				}
			}

			var messagesVector = RenderGroup.CreateRenderMessagesVector(builder, messages.ToArray());
			var renderGroup = RenderGroup.CreateRenderGroup(builder, messagesVector, index);

			builder.Finish(renderGroup.Value);
			return builder;
		}

		private void Line2D3D(Line2D3DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			//FlatBuffer doesn't like nesting "create" commands within each other so declare them early instead (vectors are immune for some reason)
			var color = command.Color.ToFlatBuffer(builder);

			RenderMessage.StartRenderMessage(builder);
			RenderMessage.AddRenderType(builder, RenderType.DrawLine2D_3D);
			RenderMessage.AddColor(builder, color);
			RenderMessage.AddStart(builder, command.Start.ToFlatBuffer(builder));
			RenderMessage.AddEnd(builder, command.End.ToFlatBuffer(builder));
			messages.Add(RenderMessage.EndRenderMessage(builder));
		}
		private void Line2D(Line2DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			PolyLine2D(new PolyLine2DCommand
			{
				Color = command.Color,
				Vectors = new[]
				{
					command.Start,
					command.End
				}
			}, builder, messages);
		}
		private void Line3D(Line3DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			PolyLine3D(new PolyLine3DCommand
			{
				Color = command.Color,
				Vectors = new[]
				{
					command.Start,
					command.End
				}
			}, builder, messages);
		}
		private void PolyLine2D(PolyLine2DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			//FlatBuffer doesn't like nesting "create" commands within each other so declare them early instead (vectors are immune for some reason)
			var color = command.Color.ToFlatBuffer(builder);
			var vectors = command.Vectors.ToArray();

			for (int i = 0, l = command.Vectors.Count() - 1; i < l; i++)
			{
				RenderMessage.StartRenderMessage(builder);
				RenderMessage.AddRenderType(builder, RenderType.DrawLine2D);
				RenderMessage.AddColor(builder, color);
				RenderMessage.AddStart(builder, vectors[i].ToFlatBuffer(builder));
				RenderMessage.AddEnd(builder, vectors[i + 1].ToFlatBuffer(builder));
				messages.Add(RenderMessage.EndRenderMessage(builder));
			}
		}
		private void PolyLine3D(PolyLine3DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			//FlatBuffer doesn't like nesting "create" commands within each other so declare them early instead (vectors are immune for some reason)
			var color = command.Color.ToFlatBuffer(builder);
			var vectors = command.Vectors.ToArray();

			for (int i = 0, l = command.Vectors.Count() - 1; i < l; i++)
			{
				RenderMessage.StartRenderMessage(builder);
				RenderMessage.AddRenderType(builder, RenderType.DrawLine3D);
				RenderMessage.AddColor(builder, color);
				RenderMessage.AddStart(builder, vectors[i].ToFlatBuffer(builder));
				RenderMessage.AddEnd(builder, vectors[i + 1].ToFlatBuffer(builder));
				messages.Add(RenderMessage.EndRenderMessage(builder));
			}
		}

		private void Rectangle2D(Rectangle2DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			//FlatBuffer doesn't like nesting "create" commands within each other so declare them early instead (vectors are immune for some reason)
			var color = command.Color.ToFlatBuffer(builder);

			RenderMessage.StartRenderMessage(builder);
			RenderMessage.AddRenderType(builder, RenderType.DrawRect2D);
			RenderMessage.AddColor(builder, color);
			RenderMessage.AddStart(builder, command.UpperLeft.ToFlatBuffer(builder));
			RenderMessage.AddScaleX(builder, command.Width);
			RenderMessage.AddScaleY(builder, command.Height);
			RenderMessage.AddIsFilled(builder, command.Filled);
			messages.Add(RenderMessage.EndRenderMessage(builder));
		}
		private void Rectangle3D(Rectangle3DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			//FlatBuffer doesn't like nesting "create" commands within each other so declare them early instead (vectors are immune for some reason)
			var color = command.Color.ToFlatBuffer(builder);

			RenderMessage.StartRenderMessage(builder);
			RenderMessage.AddRenderType(builder, command.Centered ? RenderType.DrawCenteredRect3D : RenderType.DrawRect3D);
			RenderMessage.AddColor(builder, color);
			RenderMessage.AddStart(builder, command.Position.ToFlatBuffer(builder));
			RenderMessage.AddScaleX(builder, command.Width);
			RenderMessage.AddScaleY(builder, command.Height);
			RenderMessage.AddIsFilled(builder, command.Filled);
			messages.Add(RenderMessage.EndRenderMessage(builder));
		}

		private void String2D(String2DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			//FlatBuffer doesn't like nesting "create" commands within each other so declare them early instead (vectors are immune for some reason)
			var color = command.Color.ToFlatBuffer(builder);
			var text = builder.CreateString(command.Text);

			RenderMessage.StartRenderMessage(builder);
			RenderMessage.AddRenderType(builder, RenderType.DrawString2D);
			RenderMessage.AddColor(builder, color);
			RenderMessage.AddStart(builder, command.UpperLeft.ToFlatBuffer(builder));
			RenderMessage.AddScaleX(builder, command.ScaleX);
			RenderMessage.AddScaleY(builder, command.ScaleY);
			RenderMessage.AddText(builder, text);
			messages.Add(RenderMessage.EndRenderMessage(builder));
		}
		private void String3D(String3DCommand command, FlatBufferBuilder builder, List<Offset<RenderMessage>> messages)
		{
			//FlatBuffer doesn't like nesting "create" commands within each other so declare them early instead (vectors are immune for some reason)
			var color = command.Color.ToFlatBuffer(builder);
			var text = builder.CreateString(command.Text);

			RenderMessage.StartRenderMessage(builder);
			RenderMessage.AddRenderType(builder, RenderType.DrawString3D);
			RenderMessage.AddColor(builder, color);
			RenderMessage.AddStart(builder, command.UpperLeft.ToFlatBuffer(builder));
			RenderMessage.AddScaleX(builder, command.ScaleX);
			RenderMessage.AddScaleY(builder, command.ScaleY);
			RenderMessage.AddText(builder, text);
			messages.Add(RenderMessage.EndRenderMessage(builder));
		}
	}
}
