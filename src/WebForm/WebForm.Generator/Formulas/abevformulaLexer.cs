// $ANTLR 3.1.2 abevformula.g 2011-01-22 19:07:24

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

public partial class abevformulaLexer : Lexer
{
	public const int EOF=-1;
	public const int T__8=8;
	public const int T__9=9;
	public const int T__10=10;
	public const int FUNC=4;
	public const int STRING=5;
	public const int WORD=6;
	public const int WS=7;

    // delegates
    // delegators

	public abevformulaLexer() {}
	public abevformulaLexer( ICharStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public abevformulaLexer( ICharStream input, RecognizerSharedState state )
		: base( input, state )
	{

	}
	public override string GrammarFileName { get { return "abevformula.g"; } }

	// $ANTLR start "T__8"
	private void mT__8()
	{
		try
		{
			int _type = T__8;
			int _channel = DefaultTokenChannel;
			// abevformula.g:7:8: ( ',' )
			// abevformula.g:7:8: ','
			{
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "T__8"

	// $ANTLR start "T__9"
	private void mT__9()
	{
		try
		{
			int _type = T__9;
			int _channel = DefaultTokenChannel;
			// abevformula.g:8:8: ( '[' )
			// abevformula.g:8:8: '['
			{
			Match('['); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "T__9"

	// $ANTLR start "T__10"
	private void mT__10()
	{
		try
		{
			int _type = T__10;
			int _channel = DefaultTokenChannel;
			// abevformula.g:9:9: ( ']' )
			// abevformula.g:9:9: ']'
			{
			Match(']'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "T__10"

	// $ANTLR start "WS"
	private void mWS()
	{
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// abevformula.g:33:6: ( ( '\\t' | ' ' ) )
			// abevformula.g:33:6: ( '\\t' | ' ' )
			{
			if ( input.LA(1)=='\t'||input.LA(1)==' ' )
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				Recover(mse);
				throw mse;}

			 Skip(); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "WS"

	// $ANTLR start "WORD"
	private void mWORD()
	{
		try
		{
			int _type = WORD;
			int _channel = DefaultTokenChannel;
			// abevformula.g:34:8: ( (~ ( ' ' | '\\t' | '[' | ']' | '\"' | ',' ) )+ )
			// abevformula.g:34:8: (~ ( ' ' | '\\t' | '[' | ']' | '\"' | ',' ) )+
			{
			// abevformula.g:34:8: (~ ( ' ' | '\\t' | '[' | ']' | '\"' | ',' ) )+
			int cnt1=0;
			for ( ; ; )
			{
				int alt1=2;
				int LA1_0 = input.LA(1);

				if ( ((LA1_0>='\u0000' && LA1_0<='\b')||(LA1_0>='\n' && LA1_0<='\u001F')||LA1_0=='!'||(LA1_0>='#' && LA1_0<='+')||(LA1_0>='-' && LA1_0<='Z')||LA1_0=='\\'||(LA1_0>='^' && LA1_0<='\uFFFF')) )
				{
					alt1=1;
				}


				switch ( alt1 )
				{
				case 1:
					// abevformula.g:
					{
					input.Consume();


					}
					break;

				default:
					if ( cnt1 >= 1 )
						goto loop1;

					EarlyExitException eee1 = new EarlyExitException( 1, input );
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;



			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "WORD"

	// $ANTLR start "STRING"
	private void mSTRING()
	{
		try
		{
			int _type = STRING;
			int _channel = DefaultTokenChannel;
			// abevformula.g:35:10: ( '\"' (~ '\"' )* '\"' )
			// abevformula.g:35:10: '\"' (~ '\"' )* '\"'
			{
			Match('\"'); 
			// abevformula.g:35:14: (~ '\"' )*
			for ( ; ; )
			{
				int alt2=2;
				int LA2_0 = input.LA(1);

				if ( ((LA2_0>='\u0000' && LA2_0<='!')||(LA2_0>='#' && LA2_0<='\uFFFF')) )
				{
					alt2=1;
				}


				switch ( alt2 )
				{
				case 1:
					// abevformula.g:
					{
					input.Consume();


					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;


			Match('\"'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "STRING"

	public override void mTokens()
	{
		// abevformula.g:1:10: ( T__8 | T__9 | T__10 | WS | WORD | STRING )
		int alt3=6;
		int LA3_0 = input.LA(1);

		if ( (LA3_0==',') )
		{
			alt3=1;
		}
		else if ( (LA3_0=='[') )
		{
			alt3=2;
		}
		else if ( (LA3_0==']') )
		{
			alt3=3;
		}
		else if ( (LA3_0=='\t'||LA3_0==' ') )
		{
			alt3=4;
		}
		else if ( ((LA3_0>='\u0000' && LA3_0<='\b')||(LA3_0>='\n' && LA3_0<='\u001F')||LA3_0=='!'||(LA3_0>='#' && LA3_0<='+')||(LA3_0>='-' && LA3_0<='Z')||LA3_0=='\\'||(LA3_0>='^' && LA3_0<='\uFFFF')) )
		{
			alt3=5;
		}
		else if ( (LA3_0=='\"') )
		{
			alt3=6;
		}
		else
		{
			NoViableAltException nvae = new NoViableAltException("", 3, 0, input);

			throw nvae;
		}
		switch ( alt3 )
		{
		case 1:
			// abevformula.g:1:10: T__8
			{
			mT__8(); 

			}
			break;
		case 2:
			// abevformula.g:1:15: T__9
			{
			mT__9(); 

			}
			break;
		case 3:
			// abevformula.g:1:20: T__10
			{
			mT__10(); 

			}
			break;
		case 4:
			// abevformula.g:1:26: WS
			{
			mWS(); 

			}
			break;
		case 5:
			// abevformula.g:1:29: WORD
			{
			mWORD(); 

			}
			break;
		case 6:
			// abevformula.g:1:34: STRING
			{
			mSTRING(); 

			}
			break;

		}

	}


	#region DFA

	protected override void InitDFAs()
	{
		base.InitDFAs();
	}

 
	#endregion

}
