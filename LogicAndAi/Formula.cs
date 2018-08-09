using System.Collections.Generic;
using System.Linq;

namespace LogicAndAi
{
    public abstract class Formula
    {
        public abstract bool Evaluate();
        public abstract IEnumerable<Variable> Variables();
    }

    public abstract class BinaryGate : Formula
    {
        protected readonly Formula P;
        protected readonly Formula Q;

        protected BinaryGate(Formula p, Formula q)
        {
            P = p;
            Q = q;
        }

        public override IEnumerable<Variable> Variables()
        {
            return P.Variables().Concat(Q.Variables());
        }
    }

    public class And : BinaryGate
    {
        public And(Formula p, Formula q) : base(p, q) { }

        public override bool Evaluate()
        {
            return P.Evaluate() && Q.Evaluate();
        }
    }

    public class Or : BinaryGate
    {
        public Or(Formula p, Formula q) : base(p, q) { }

        public override bool Evaluate()
        {
            return P.Evaluate() || Q.Evaluate();
        }
    }

    public class Not : Formula
    {
        private readonly Formula _p;

        public Not(Formula p)
        {
            _p = p;
        }

        public override bool Evaluate()
        {
            return !_p.Evaluate();
        }

        public override IEnumerable<Variable> Variables()
        {
            return new List<Variable>(_p.Variables());
        }
    }

    public class Variable : Formula
    {
        public bool Value { get; set; }

        public Variable(bool value)
        {
            Value = value;
        }

        public override bool Evaluate()
        {
            return Value;
        }

        public override IEnumerable<Variable> Variables()
        {
            return new List<Variable> { this };
        }

    }
}
