﻿using IbanNet.Registry;

namespace IbanNet.Validation.Rules
{
	/// <summary>
	/// The validation context for a validation rule.
	/// </summary>
	public class ValidationRuleContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ValidationRuleContext"/> class.
		/// </summary>
		/// <param name="country">The country info (if any).</param>
		public ValidationRuleContext(CountryInfo? country)
		{
			Country = country;
		}

		/// <summary>
		/// Gets or sets the country info that applies to the IBAN, if any.
		/// </summary>
		public CountryInfo? Country { get; set; }
	}
}