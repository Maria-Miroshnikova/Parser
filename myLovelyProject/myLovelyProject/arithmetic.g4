// Template generated code from Antlr4BuildTasks.Template v 2.1
grammar arithmetic;

file : expression (SEMI expression)* EOF;

expression
   :  left=expression op=(TIMES | DIV) right=expression
   |  left=expression op=(PLUS | MINUS) right=expression
   |  left=expression op=(AND | OR | BOOLEQ) right=expression
   |  LPAREN evalue=expression RPAREN
   |  op=(MINUS | NOT)+ LPAREN evalue=expression RPAREN
   |  op=(MINUS | NOT)* avalue=atom
   ;

atom
   : number
   | bool
   | identifier
   ;


bool
   : true
   | false
   ;


true
   : TRUE
   ;


false
   : FALSE
   ;


identifier
   : nameIdentifier typeIdentifier
   ;


nameIdentifier
   : NAMEIDENTIFIER
   ;


typeIdentifier
   : variable
   | function
   ;


function
   : LPAREN (expression (',' expression)*)? RPAREN
   ;

variable
   :
   ;

number
   : int
   | double
   ;


int
   : INT
   ;


double
   : DOUBLE
   ;


// this rules for TRUE and FALSE must be before rules for variables and functions names!
TRUE
   : 'true'
   ;


FALSE
   : 'false'
   ;


NAMEIDENTIFIER
   : VALID_ID_START VALID_ID_CHAR* VALID_ID_END*
   ;


fragment VALID_ID_START
   : ('a' .. 'z') | ('A' .. 'Z')
   ;


fragment VALID_ID_CHAR
   : VALID_ID_START
   ;


fragment VALID_ID_END
   : ('0' .. '9')
   ;


//The NUMBER part gets its potential sign from "(PLUS | MINUS)* atom" in the expression rule
INT
   : ('0' .. '9') +
   ;


DOUBLE
   : ('0' .. '9') + ('.' ('0' .. '9') +) +
   ;


LPAREN: '(' ;

RPAREN: ')' ;

PLUS: '+' ;

MINUS: '-' ;

TIMES: '*' ;

DIV: '/' ;

AND: '&&' ;

OR: '||' ;

NOT: '!' ;

BOOLEQ: '==' ;

POINT : '.' ;

SEMI : ';' ;

WS
   : [ \r\n\t] + -> skip
   ;

// this rule must be after multicharactered lexer rules including TRUE, FALSE, AND, OR, BOOLEQ, and WS!
UNEXPECTED
   : ~( 'a'..'z' | 'A'..'Z' | '0'..'9' | '*' | '/' | '+' | '-' | '!' | ';' | ',' | '(' | ')')
   ;