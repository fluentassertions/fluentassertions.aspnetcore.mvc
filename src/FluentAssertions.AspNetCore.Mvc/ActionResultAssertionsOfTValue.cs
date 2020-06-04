#if NETCOREAPP3_0
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentAssertions.AspNetCore.Mvc
{
    /// <summary>
    /// Contains a number of methods to assert that an <see cref="ActionResult"/> is in the expected state.
    /// </summary>
    [DebuggerNonUserCode]
    public class ActionResultAssertions<TValue> : ReferenceTypeAssertions<ActionResult<TValue>, ActionResultAssertions<TValue>>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionResultAssertions{TValue}" /> class.
        /// </summary>
        public ActionResultAssertions(ActionResult<TValue> subject)
        {
            Subject = subject;
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <inheritdoc />
        protected override string Identifier { get; } = $"ActionResult<{typeof(TValue).Name}>";

        #endregion Protected Properties

        #region Public Properties

        /// <summary>
        /// Gets the <see cref="ActionResult{TValue}.Result"/> of the actual Subjhect.
        /// </summary>
        public ActionResult Result => Subject.Result;

        /// <summary>
        /// Gets the <see cref="ActionResult{TValue}.Value"/> of the actual Subjhect.
        /// </summary>
        public TValue Value => Subject.Value;

        #endregion Public Properties

        #region Public Methods

        /// TODO What should be here?
        
        #endregion Public Methods
    }
}
#endif