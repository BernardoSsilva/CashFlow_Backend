using Cashflow.Application.UseCases.Expenses.Create;
using Cashflow.Communication.Enums;
using Cashflow.Exception;
using CommonTestsUtilities.Requests;
using FluentAssertions;

namespace ValidatorsTests.Expenses.Register
{
    public class RegisterExpensesTest
    {
        [Fact]
        public void Success()
        {

            // Arange
            var validator = new RegisterExpenseValidator();
            var request =  RequestRegisterExpenseJsonBuilder.Build();

            // act
            var result = validator.Validate(request);

            
            //assert
            result.IsValid.Should().BeTrue();

        }

        [Fact]
        public void TitleError()
        {

            // Arange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Title = string.Empty;

            // act
            var result = validator.Validate(request);


            //assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.TITLE_ERROR));

        }


        [Fact]
        public void AmountError()
        {

            // Arange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Amount = 0;
            // act
            var result = validator.Validate(request);


            //assert
            result.IsValid.Should().BeFalse();
            
            result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.INITIAL_DATE_BEFORE_PRESENT));

        }

        [Fact]

        public void DateError()
        {

            // Arange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Date = new DateTime().AddDays(2);
            // act
            var result = validator.Validate(request);


            //assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.INITIAL_DATE_BEFORE_PRESENT));

        }

        [Fact]

        public void PaymentTypeError()
        {

            // Arange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.PaymentType =  (PaymentTypes) 500;
            // act
            var result = validator.Validate(request);


            //assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals(ResourceErrorMessages.UNKNOWN_PAYMENT_TYPE));

        }
    }
}
