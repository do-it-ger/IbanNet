﻿using System;
using IbanNet.Validation.Results;
using Moq;

namespace IbanNet
{
    public class IbanTestFixture
    {
        protected Mock<IIbanValidator> IbanValidatorMock { get; }

        public IbanTestFixture()
        {
            IbanValidatorMock = new Mock<IIbanValidator>();

            IbanValidatorMock
                .Setup(m => m.Validate(It.IsAny<string>()))
                .Returns<string>(iban => new ValidationResult
                {
                    AttemptedValue = iban
                });

            IbanValidatorMock
                .Setup(m => m.Validate(null))
                .Returns<string>(iban => new ValidationResult
                {
                    AttemptedValue = null,
                    Error = new InvalidLengthResult()
                });

            IbanValidatorMock
                .Setup(m => m.Validate(TestValues.InvalidIban))
                .Returns<string>(iban => new ValidationResult
                {
                    AttemptedValue = iban,
                    Error = new IllegalCharactersResult()
                });

            IbanValidatorMock
                .Setup(m => m.Validate(TestValues.IbanForCustomRuleFailure))
                .Returns<string>(iban => new ValidationResult
                {
                    AttemptedValue = iban,
                    Error = new ErrorResult("Custom message")
                });

            IbanValidatorMock
                .Setup(m => m.Validate(TestValues.IbanForCustomRuleException))
                .Throws(new InvalidOperationException("Custom message"));

            Iban.Validator = IbanValidatorMock.Object;
        }
    }
}
