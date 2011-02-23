grammar abevformula;

options {
    language = CSharp3;
    output       = AST;
    ASTLabelType = CommonTree;
    backtrack    = true;
    memoize      = true;
}

tokens {
	FUNC;
}

@members {
	public abevformulaParser.start_return startIt()
	{
		return this.start();
	}
}

start		: funcwithparams ;

funcwithparams	: '[' func ',' paramlist ']' -> ^(FUNC func paramlist);
func		: WORD ;
paramlist	: param (',' param)* -> param+;
word		: WORD ;
sentence	: STRING ;
param		: word 
			| sentence
			| funcwithparams;

WS : ('\t' | ' ' ) { Skip(); } ;
WORD	: ( ~(' ' | '\t' | '[' | ']' | '"' | ',') )+ ;
STRING	: '"' (~'"')* '"' ;


/*
tree grammar abevformula;

options {
    language = CSharp3;
    //output       = AST;
    ASTLabelType = CommonTree;
    backtrack    = true;
    memoize      = true;
}

@members {
	public abevformulaParser.start_return startIt()
	{
		return this.start();
	}
}

start		: funcwithparams ;

funcwithparams	: '[' func ',' paramlist ']' ;
func		: STRING ;
paramlist	: param (',' param)* ;

param		: STRING | '"' STRING '"' | funcwithparams;

//WS : ('\t' | ' ' ) { Skip(); } ;
//WORD	: ( ~(' ' | '\t' | '[' | ']' | '"' | ',') )+ ;

*/