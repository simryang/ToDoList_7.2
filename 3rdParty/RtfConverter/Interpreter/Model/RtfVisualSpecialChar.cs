﻿// -- FILE ------------------------------------------------------------------
// name       : RtfVisualSpecialChar.cs
// project    : RTF Framelet
// created    : Leon Poyyayil - 2008.05.22
// language   : c#
// environment: .NET 2.0
// copyright  : (c) 2004-2009 by Itenso GmbH, Switzerland
// --------------------------------------------------------------------------
using Itenso.Sys;

namespace Itenso.Rtf.Model
{

	// ------------------------------------------------------------------------
	public sealed class RtfVisualSpecialChar : RtfVisual, IRtfVisualSpecialChar
	{

		// ----------------------------------------------------------------------
		public RtfVisualSpecialChar( RtfVisualSpecialCharKind charKind ) :
			base( RtfVisualKind.Special )
		{
			this.charKind = charKind;
		} // RtfVisualSpecialChar

		// ----------------------------------------------------------------------
		protected override void DoVisit( IRtfVisualVisitor visitor )
		{
			visitor.VisitSpecial( this );
		} // DoVisit

		// ----------------------------------------------------------------------
		public RtfVisualSpecialCharKind CharKind
		{
			get { return this.charKind; }
		} // CharKind

		// ----------------------------------------------------------------------
		protected override bool IsEqual( object obj )
		{
			RtfVisualSpecialChar compare = obj as RtfVisualSpecialChar; // guaranteed to be non-null
			return 
				compare != null &&
				base.IsEqual( compare ) &&
				this.charKind == compare.charKind;
		} // IsEqual

		// ----------------------------------------------------------------------
		protected override int ComputeHashCode()
		{
			return HashTool.AddHashCode( base.ComputeHashCode(), this.charKind );
		} // ComputeHashCode

		// ----------------------------------------------------------------------
		public override string ToString()
		{
			return this.charKind.ToString();
		} // ToString

		// ----------------------------------------------------------------------
		// members
		private readonly RtfVisualSpecialCharKind charKind;

	} // class RtfVisualSpecialChar

} // namespace Itenso.Rtf.Model
// -- EOF -------------------------------------------------------------------
