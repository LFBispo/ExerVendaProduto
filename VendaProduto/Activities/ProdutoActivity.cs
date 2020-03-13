using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using VendaProduto.Adapters;
using VendaProduto.Classes;
using ToolbarV7 = Android.Support.V7.Widget.Toolbar;

namespace VendaProduto.Activities
{
    /// <summary>
    /// Activity que irá gerenciar produtos. (CRUD)
    /// Uma lista de produtos é carregada numa list (que é adaptada e exibida numa ListView).
    /// </summary>
    [Activity()]
    public class ProdutoActivity : AppCompatActivity
    {
        ToolbarV7 tlbProduto;

        //TODO - Criar o método ItemClick e ItemLongClick do lstProdutos.
        //ItemClick: irá abrir uma NOVA ACTIVITY com os dados do produto tocado para EDIÇÃO.
        //ItemLongClick: irá perguntar ao usuário se o produto selecionado será DESATIVADO (Ativo = 0)
        ListView lstProdutos;

        List<Produto> produtos = new Produto().BuscarTodosProdutos();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_produto);

            tlbProduto = FindViewById<ToolbarV7>(Resource.Id.tlbProduto);
            lstProdutos = FindViewById<ListView>(Resource.Id.lstProdutos);

            SetSupportActionBar(tlbProduto);
            SupportActionBar.Title = "Gerenciar Produtos";

            AdaptadorProdutos adp = new AdaptadorProdutos(this, produtos);
            lstProdutos.Adapter = adp;

            lstProdutos.ItemClick += LstProdutos_ItemClick;
            lstProdutos.ItemLongClick += LstProdutos_ItemLongClick;
        }

        private void LstProdutos_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LstProdutos_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbar_produto, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.tlbItem_addProduto:
                    Intent tlAddProd = new Intent(this, typeof(AddProdutoActivity));
                    StartActivity(tlAddProd);
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}