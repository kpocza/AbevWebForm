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
using Map = System.Collections.IDictionary;
using HashMap = System.Collections.Generic.Dictionary<object, object>;

using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

public partial class abevformulaParser : Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "FUNC", "STRING", "WORD", "WS", "','", "'['", "']'"
	};
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

	public abevformulaParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public abevformulaParser( ITokenStream input, RecognizerSharedState state )
		: base( input, state )
	{
		this.state.ruleMemo = new System.Collections.Generic.Dictionary<int, int>[10+1];

		InitializeTreeAdaptor();
		if ( TreeAdaptor == null )
			TreeAdaptor = new CommonTreeAdaptor();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void InitializeTreeAdaptor();
	ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return abevformulaParser.tokenNames; } }
	public override string GrammarFileName { get { return "abevformula.g"; } }


		public abevformulaParser.start_return startIt()
		{
			return this.start();
		}


	#region Rules
	public class start_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "start"
	// abevformula.g:22:0: start : funcwithparams ;
	private abevformulaParser.start_return start(  )
	{
		abevformulaParser.start_return retval = new abevformulaParser.start_return();
		retval.start = input.LT(1);
		int start_StartIndex = input.Index;
		CommonTree root_0 = null;

		abevformulaParser.funcwithparams_return funcwithparams1 = default(abevformulaParser.funcwithparams_return);


		try
		{
			if ( state.backtracking>0 && AlreadyParsedRule(input, 1) ) { return retval; }
			// abevformula.g:22:10: ( funcwithparams )
			// abevformula.g:22:10: funcwithparams
			{
			root_0 = (CommonTree)adaptor.Nil();

			PushFollow(Follow._funcwithparams_in_start100);
			funcwithparams1=funcwithparams();

			state._fsp--;
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) adaptor.AddChild(root_0, funcwithparams1.Tree);

			}

			retval.stop = input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);
			}
		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
			if ( state.backtracking>0 ) { Memoize(input, 1, start_StartIndex); }
		}
		return retval;
	}
	// $ANTLR end "start"

	public class funcwithparams_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "funcwithparams"
	// abevformula.g:24:0: funcwithparams : '[' func ',' paramlist ']' -> ^( FUNC func paramlist ) ;
	private abevformulaParser.funcwithparams_return funcwithparams(  )
	{
		abevformulaParser.funcwithparams_return retval = new abevformulaParser.funcwithparams_return();
		retval.start = input.LT(1);
		int funcwithparams_StartIndex = input.Index;
		CommonTree root_0 = null;

		IToken char_literal2=null;
		IToken char_literal4=null;
		IToken char_literal6=null;
		abevformulaParser.func_return func3 = default(abevformulaParser.func_return);
		abevformulaParser.paramlist_return paramlist5 = default(abevformulaParser.paramlist_return);

		CommonTree char_literal2_tree=null;
		CommonTree char_literal4_tree=null;
		CommonTree char_literal6_tree=null;
		RewriteRuleITokenStream stream_9=new RewriteRuleITokenStream(adaptor,"token 9");
		RewriteRuleITokenStream stream_8=new RewriteRuleITokenStream(adaptor,"token 8");
		RewriteRuleITokenStream stream_10=new RewriteRuleITokenStream(adaptor,"token 10");
		RewriteRuleSubtreeStream stream_func=new RewriteRuleSubtreeStream(adaptor,"rule func");
		RewriteRuleSubtreeStream stream_paramlist=new RewriteRuleSubtreeStream(adaptor,"rule paramlist");
		try
		{
			if ( state.backtracking>0 && AlreadyParsedRule(input, 2) ) { return retval; }
			// abevformula.g:24:18: ( '[' func ',' paramlist ']' -> ^( FUNC func paramlist ) )
			// abevformula.g:24:18: '[' func ',' paramlist ']'
			{
			char_literal2=(IToken)Match(input,9,Follow._9_in_funcwithparams109); if (state.failed) return retval; 
			if ( state.backtracking == 0 ) stream_9.Add(char_literal2);

			PushFollow(Follow._func_in_funcwithparams111);
			func3=func();

			state._fsp--;
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) stream_func.Add(func3.Tree);
			char_literal4=(IToken)Match(input,8,Follow._8_in_funcwithparams113); if (state.failed) return retval; 
			if ( state.backtracking == 0 ) stream_8.Add(char_literal4);

			PushFollow(Follow._paramlist_in_funcwithparams115);
			paramlist5=paramlist();

			state._fsp--;
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) stream_paramlist.Add(paramlist5.Tree);
			char_literal6=(IToken)Match(input,10,Follow._10_in_funcwithparams117); if (state.failed) return retval; 
			if ( state.backtracking == 0 ) stream_10.Add(char_literal6);



			{
			// AST REWRITE
			// elements: func, paramlist
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			if ( state.backtracking == 0 ) {
			retval.tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.tree:null);

			root_0 = (CommonTree)adaptor.Nil();
			// 24:45: -> ^( FUNC func paramlist )
			{
				// abevformula.g:24:48: ^( FUNC func paramlist )
				{
				CommonTree root_1 = (CommonTree)adaptor.Nil();
				root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(FUNC, "FUNC"), root_1);

				adaptor.AddChild(root_1, stream_func.NextTree());
				adaptor.AddChild(root_1, stream_paramlist.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.tree = root_0;
			}
			}

			}

			retval.stop = input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);
			}
		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
			if ( state.backtracking>0 ) { Memoize(input, 2, funcwithparams_StartIndex); }
		}
		return retval;
	}
	// $ANTLR end "funcwithparams"

	public class func_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "func"
	// abevformula.g:25:0: func : WORD ;
	private abevformulaParser.func_return func(  )
	{
		abevformulaParser.func_return retval = new abevformulaParser.func_return();
		retval.start = input.LT(1);
		int func_StartIndex = input.Index;
		CommonTree root_0 = null;

		IToken WORD7=null;

		CommonTree WORD7_tree=null;

		try
		{
			if ( state.backtracking>0 && AlreadyParsedRule(input, 3) ) { return retval; }
			// abevformula.g:25:9: ( WORD )
			// abevformula.g:25:9: WORD
			{
			root_0 = (CommonTree)adaptor.Nil();

			WORD7=(IToken)Match(input,WORD,Follow._WORD_in_func135); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			WORD7_tree = (CommonTree)adaptor.Create(WORD7);
			adaptor.AddChild(root_0, WORD7_tree);
			}

			}

			retval.stop = input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);
			}
		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
			if ( state.backtracking>0 ) { Memoize(input, 3, func_StartIndex); }
		}
		return retval;
	}
	// $ANTLR end "func"

	public class paramlist_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "paramlist"
	// abevformula.g:26:0: paramlist : param ( ',' param )* -> ( param )+ ;
	private abevformulaParser.paramlist_return paramlist(  )
	{
		abevformulaParser.paramlist_return retval = new abevformulaParser.paramlist_return();
		retval.start = input.LT(1);
		int paramlist_StartIndex = input.Index;
		CommonTree root_0 = null;

		IToken char_literal9=null;
		abevformulaParser.param_return param8 = default(abevformulaParser.param_return);
		abevformulaParser.param_return param10 = default(abevformulaParser.param_return);

		CommonTree char_literal9_tree=null;
		RewriteRuleITokenStream stream_8=new RewriteRuleITokenStream(adaptor,"token 8");
		RewriteRuleSubtreeStream stream_param=new RewriteRuleSubtreeStream(adaptor,"rule param");
		try
		{
			if ( state.backtracking>0 && AlreadyParsedRule(input, 4) ) { return retval; }
			// abevformula.g:26:13: ( param ( ',' param )* -> ( param )+ )
			// abevformula.g:26:13: param ( ',' param )*
			{
			PushFollow(Follow._param_in_paramlist143);
			param8=param();

			state._fsp--;
			if (state.failed) return retval;
			if ( state.backtracking == 0 ) stream_param.Add(param8.Tree);
			// abevformula.g:26:19: ( ',' param )*
			for ( ; ; )
			{
				int alt1=2;
				int LA1_0 = input.LA(1);

				if ( (LA1_0==8) )
				{
					alt1=1;
				}


				switch ( alt1 )
				{
				case 1:
					// abevformula.g:26:20: ',' param
					{

					char_literal9=(IToken)Match(input,8,Follow._8_in_paramlist146); if (state.failed) return retval; 
					if ( state.backtracking == 0 ) stream_8.Add(char_literal9);

					PushFollow(Follow._param_in_paramlist148);
					param10=param();

					state._fsp--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) stream_param.Add(param10.Tree);

					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;




			{
			// AST REWRITE
			// elements: param
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			if ( state.backtracking == 0 ) {
			retval.tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.tree:null);

			root_0 = (CommonTree)adaptor.Nil();
			// 26:32: -> ( param )+
			{
				if ( !(stream_param.HasNext) )
				{
					throw new RewriteEarlyExitException();
				}
				while ( stream_param.HasNext )
				{
					adaptor.AddChild(root_0, stream_param.NextTree());

				}
				stream_param.Reset();

			}

			retval.tree = root_0;
			}
			}

			}

			retval.stop = input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);
			}
		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
			if ( state.backtracking>0 ) { Memoize(input, 4, paramlist_StartIndex); }
		}
		return retval;
	}
	// $ANTLR end "paramlist"

	public class word_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "word"
	// abevformula.g:27:0: word : WORD ;
	private abevformulaParser.word_return word(  )
	{
		abevformulaParser.word_return retval = new abevformulaParser.word_return();
		retval.start = input.LT(1);
		int word_StartIndex = input.Index;
		CommonTree root_0 = null;

		IToken WORD11=null;

		CommonTree WORD11_tree=null;

		try
		{
			if ( state.backtracking>0 && AlreadyParsedRule(input, 5) ) { return retval; }
			// abevformula.g:27:9: ( WORD )
			// abevformula.g:27:9: WORD
			{
			root_0 = (CommonTree)adaptor.Nil();

			WORD11=(IToken)Match(input,WORD,Follow._WORD_in_word163); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			WORD11_tree = (CommonTree)adaptor.Create(WORD11);
			adaptor.AddChild(root_0, WORD11_tree);
			}

			}

			retval.stop = input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);
			}
		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
			if ( state.backtracking>0 ) { Memoize(input, 5, word_StartIndex); }
		}
		return retval;
	}
	// $ANTLR end "word"

	public class sentence_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "sentence"
	// abevformula.g:28:0: sentence : STRING ;
	private abevformulaParser.sentence_return sentence(  )
	{
		abevformulaParser.sentence_return retval = new abevformulaParser.sentence_return();
		retval.start = input.LT(1);
		int sentence_StartIndex = input.Index;
		CommonTree root_0 = null;

		IToken STRING12=null;

		CommonTree STRING12_tree=null;

		try
		{
			if ( state.backtracking>0 && AlreadyParsedRule(input, 6) ) { return retval; }
			// abevformula.g:28:12: ( STRING )
			// abevformula.g:28:12: STRING
			{
			root_0 = (CommonTree)adaptor.Nil();

			STRING12=(IToken)Match(input,STRING,Follow._STRING_in_sentence171); if (state.failed) return retval;
			if ( state.backtracking==0 ) {
			STRING12_tree = (CommonTree)adaptor.Create(STRING12);
			adaptor.AddChild(root_0, STRING12_tree);
			}

			}

			retval.stop = input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);
			}
		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
			if ( state.backtracking>0 ) { Memoize(input, 6, sentence_StartIndex); }
		}
		return retval;
	}
	// $ANTLR end "sentence"

	public class param_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "param"
	// abevformula.g:29:0: param : ( word | sentence | funcwithparams );
	private abevformulaParser.param_return param(  )
	{
		abevformulaParser.param_return retval = new abevformulaParser.param_return();
		retval.start = input.LT(1);
		int param_StartIndex = input.Index;
		CommonTree root_0 = null;

		abevformulaParser.word_return word13 = default(abevformulaParser.word_return);
		abevformulaParser.sentence_return sentence14 = default(abevformulaParser.sentence_return);
		abevformulaParser.funcwithparams_return funcwithparams15 = default(abevformulaParser.funcwithparams_return);


		try
		{
			if ( state.backtracking>0 && AlreadyParsedRule(input, 7) ) { return retval; }
			// abevformula.g:29:10: ( word | sentence | funcwithparams )
			int alt2=3;
			switch ( input.LA(1) )
			{
			case WORD:
				{
				alt2=1;
				}
				break;
			case STRING:
				{
				alt2=2;
				}
				break;
			case 9:
				{
				alt2=3;
				}
				break;
			default:
				{
					if (state.backtracking>0) {state.failed=true; return retval;}
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

					throw nvae;
				}
			}

			switch ( alt2 )
			{
			case 1:
				// abevformula.g:29:10: word
				{
				root_0 = (CommonTree)adaptor.Nil();


				PushFollow(Follow._word_in_param180);
				word13=word();

				state._fsp--;
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, word13.Tree);

				}
				break;
			case 2:
				// abevformula.g:30:6: sentence
				{
				root_0 = (CommonTree)adaptor.Nil();


				PushFollow(Follow._sentence_in_param188);
				sentence14=sentence();

				state._fsp--;
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sentence14.Tree);

				}
				break;
			case 3:
				// abevformula.g:31:6: funcwithparams
				{
				root_0 = (CommonTree)adaptor.Nil();

				PushFollow(Follow._funcwithparams_in_param195);
				funcwithparams15=funcwithparams();

				state._fsp--;
				if (state.failed) return retval;
				if ( state.backtracking == 0 ) adaptor.AddChild(root_0, funcwithparams15.Tree);

				}
				break;

			}
			retval.stop = input.LT(-1);

			if ( state.backtracking == 0 ) {

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);
			}
		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
			if ( state.backtracking>0 ) { Memoize(input, 7, param_StartIndex); }
		}
		return retval;
	}
	// $ANTLR end "param"
	#endregion Rules


	#region Follow sets
	static class Follow
	{
		public static readonly BitSet _funcwithparams_in_start100 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _9_in_funcwithparams109 = new BitSet(new ulong[]{0x40UL});
		public static readonly BitSet _func_in_funcwithparams111 = new BitSet(new ulong[]{0x100UL});
		public static readonly BitSet _8_in_funcwithparams113 = new BitSet(new ulong[]{0x260UL});
		public static readonly BitSet _paramlist_in_funcwithparams115 = new BitSet(new ulong[]{0x400UL});
		public static readonly BitSet _10_in_funcwithparams117 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _WORD_in_func135 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _param_in_paramlist143 = new BitSet(new ulong[]{0x102UL});
		public static readonly BitSet _8_in_paramlist146 = new BitSet(new ulong[]{0x260UL});
		public static readonly BitSet _param_in_paramlist148 = new BitSet(new ulong[]{0x102UL});
		public static readonly BitSet _WORD_in_word163 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _STRING_in_sentence171 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _word_in_param180 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _sentence_in_param188 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _funcwithparams_in_param195 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}
