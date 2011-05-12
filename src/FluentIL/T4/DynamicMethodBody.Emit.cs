﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Reflection;
using System.Diagnostics;

namespace FluentIL
{
	public partial class DynamicMethodBody
	{
		readonly Stack<Action> PreEmitActions = new Stack<Action>();
		private void ExecutePreEmitActions()
		{
			while ( PreEmitActions.Count > 0 ) 
                PreEmitActions.Pop()();
		}

		#region Emit (basic)
        public DynamicMethodBody Emit(OpCode opcode)
        {
			ExecutePreEmitActions();
			#if DEBUG
			Debug.WriteLine(string.Format("\t{0}", opcode));
			#endif
            _Info.GetILGenerator()
                .Emit(opcode);

            return this;
        }
        #endregion


		public DynamicMethodBody Emit(OpCode opcode, string arg)
        {
			ExecutePreEmitActions();
			#if DEBUG
						Debug.WriteLine("\t{0} \"{1}\"", opcode, arg);
						#endif
			
			_Info.GetILGenerator()
                .Emit(opcode, arg);

            return this;
        }

		public DynamicMethodBody Emit(OpCode opcode, int arg)
        {
			ExecutePreEmitActions();
			#if DEBUG
						Debug.WriteLine("\t{0} {1}", opcode, arg.ToString());
						#endif
			
			_Info.GetILGenerator()
                .Emit(opcode, arg);

            return this;
        }

		public DynamicMethodBody Emit(OpCode opcode, double arg)
        {
			ExecutePreEmitActions();
			#if DEBUG
						Debug.WriteLine("\t{0} {1}", opcode, arg.ToString());
						#endif
			
			_Info.GetILGenerator()
                .Emit(opcode, arg);

            return this;
        }

		public DynamicMethodBody Emit(OpCode opcode, Label arg)
        {
			ExecutePreEmitActions();
			#if DEBUG
						Debug.WriteLine("\t{0} IL_{1}", opcode, arg.GetHashCode());
						#endif
			
			_Info.GetILGenerator()
                .Emit(opcode, arg);

            return this;
        }

		public DynamicMethodBody Emit(OpCode opcode, MethodInfo arg)
        {
			ExecutePreEmitActions();
			#if DEBUG
						Debug.WriteLine("\t{0} {1}", opcode, arg.ToString());
						#endif
			
			_Info.GetILGenerator()
                .Emit(opcode, arg);

            return this;
        }

		public DynamicMethodBody Emit(OpCode opcode, ConstructorInfo arg)
        {
			ExecutePreEmitActions();
			#if DEBUG
						Debug.WriteLine("\t{0} {1}", opcode, arg.ToString());
						#endif
			
			_Info.GetILGenerator()
                .Emit(opcode, arg);

            return this;
        }

		public DynamicMethodBody Emit(OpCode opcode, FieldInfo arg)
        {
			ExecutePreEmitActions();
			#if DEBUG
						Debug.WriteLine("\t{0} {1}", opcode, arg.Name);
						#endif
			
			_Info.GetILGenerator()
                .Emit(opcode, arg);

            return this;
        }

	}
}
