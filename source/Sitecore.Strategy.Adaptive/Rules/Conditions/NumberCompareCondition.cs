﻿using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Strategy.Adaptive.Rules.Conditions
{
    public class NumberCompareCondition<T> : OperatorCondition<T> where T : RuleContext
    {
        public double LeftValue { get; set; }
        public double RightValue { get; set; }
        
        protected virtual bool Compare(double leftValue, double rightValue)
        {
            switch (base.GetOperator())
            {
                case ConditionOperator.Equal:
                    return (Math.Abs(leftValue - rightValue) < 0.000001);

                case ConditionOperator.GreaterThanOrEqual:
                    return (leftValue >= rightValue);

                case ConditionOperator.GreaterThan:
                    return (leftValue > rightValue);

                case ConditionOperator.LessThanOrEqual:
                    return (leftValue <= rightValue);

                case ConditionOperator.LessThan:
                    return (leftValue < rightValue);

                case ConditionOperator.NotEqual:
                    return (Math.Abs(leftValue - rightValue) > 0.000001);
            }
            return false;
        }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull(ruleContext, "ruleContext");
            return this.Compare(this.LeftValue, this.RightValue);
        }
    }
}