import React, { Component } from 'react'
import './Home.css'
import Pizzaria from '../../Components/Pizzaria-component'
import api from '../../Services/api'
import { parseJwt } from '../../Services/auth'

export default class Home extends Component {
    constructor() {
        super()
        this.state = {
            pizzarias: [],
            token: '',
            email: '',
            senha: '',
            mensagemErro: '',
            credencial: '',
                CadastroNome: '',
                CadastroEndereco: '',
                CadastroNumero: '',
                CadastroTelefone: '',
                CadastroVegana: false,
                CadastroIdCategoria: 1,
                mensagemCadastro: '',
                erroCadastro: '',
        }
    }

    // Fazendo request para listar as pizzarias
    fazerRequest = async () => {
        const resposta = await api.get('/pizzarias', {
            headers: {
                'Authorization': 'Bearer ' + this.state.token
            }
        })

        this.setState({ pizzarias: resposta.data })
    }

    // Funções para atualizar states
    atualizarEstadoEmail(e) {
        this.setState({ email: e.target.value })
    }

    atualizarEstadoSenha(e) {
        this.setState({ senha: e.target.value })
    }

    atualizarCadastroNome(e) {
        this.setState({ CadastroNome: e.target.value })
    }

    atualizarCadastroEndereco(e) {
        this.setState({ CadastroEndereco: e.target.value })
    }

    atualizarCadastroNumero(e) {
        this.setState({ CadastroNumero: e.target.value })
    }

    atualizarCadastroTelefone(e) {
        this.setState({ CadastroTelefone: e.target.value })
    }

    atualizarCadastroVegana(e) {
        if (this.state.CadastroVegana === false) {
            this.setState({ CadastroVegana: true })
        } else {
            this.setState({ CadastroVegana: false })
        }
    }


    // Função para efetuar login
    efetuarLogin = async (e) => {
        e.preventDefault()

        await api.post("/login", {
            email: this.state.email,
            senha: this.state.senha
        })
            .then(data => {
                if (data.status === 200) {
                    this.setState({ token: data.data.token })
                    localStorage.setItem('token', this.state.token)
                    var credencial = Object.values(parseJwt())[1]
                    this.setState({ credencial: credencial })
                }
            }).catch(erro => {
                this.setState({ mensagemErro: 'Email ou Senha Inválidos' })
            })


        this.fazerRequest()

    }

    //Função para cadastrar uma nova pizzaria
    CadastrarPizzaria = async (e) => {
        e.preventDefault()
        var cat = document.getElementById("categorias").value;
        this.setState({ CadastroIdCategoria: cat })

        await api.post('/pizzarias', {
            nome: this.state.CadastroNome,
            endereco: this.state.CadastroEndereco,
            numero: this.state.CadastroNumero,
            telefone: this.state.CadastroTelefone,
            vegana: this.state.CadastroVegana,
            idCategoria: this.state.CadastroIdCategoria,
        }, {
                headers: {
                    'Authorization': 'Bearer ' + this.state.token
                }
            }).then(data => {
                if (data.status === 200) {
                    this.setState({mensagemCadastro: 'Pizzaria cadastrada com sucesso'})
                }
            }).catch(erro => {
                this.setState({erroCadastro: 'Erro no cadastro'})
            })
    }

    render() {
        return (
            <div>
                <div className="header">
                    <section>
                        <div className="texto">
                            <h1>AS MELHORES PIZZARIAS DA REGIÃO</h1>
                        </div>
                        <div className="imagem">
                        </div>
                    </section>
                </div>
                {/* If ternário - renderiza a lista de pizzarias após a request ter sido feita */}
                {this.state.token !== ''
                    ?
                    <div className="lista">
                        {this.state.pizzarias.map(key => {
                            return <Pizzaria
                                nome={key.nome}
                                endereco={key.endereco}
                                numero={key.numero}
                                telefone={key.telefone}
                                vegana={key.vegana}
                                categoria={key.idCategoria}
                            />
                        })}
                    </div>
                    :
                    <div className="lista">
                        <div className="card-login">
                            <h2>Faça seu login para ver as pizzarias disponíveis</h2>
                            <form onSubmit={this.efetuarLogin.bind(this)}>
                                <input placeholder="Email" type="text" onChange={this.atualizarEstadoEmail.bind(this)} className="input-text" />
                                <input placeholder="Senha" type="password" onChange={this.atualizarEstadoSenha.bind(this)} className="input-text" />
                                <center>
                                    {this.state.mensagemErro !== '' ? <h5>{this.state.mensagemErro}</h5> : null}
                                    <input type="submit" className="input-btn" value="Fazer login" />
                                </center>
                            </form>
                        </div>
                    </div>
                }

                {/* If ternário - Renderiza o formulário de cadastro caso o usuario logado seja administrador */}
                {
                    this.state.credencial === 'administrador' ? <div className="lista">
                        <div className="card-login">
                            <h2>Cadastre uma nova pizzaria</h2>
                            <form onSubmit={this.CadastrarPizzaria.bind(this)}>

                                <input type="text" placeholder="Nome da pizzaria" name="nome" onChange={this.atualizarCadastroNome.bind(this)} className="input-text" />

                                <input type="text" placeholder="Endereço" name="endereco" onChange={this.atualizarCadastroEndereco.bind(this)} className="input-text" />

                                <input type="text" placeholder="Número" name="numero" onChange={this.atualizarCadastroNumero.bind(this)} className="input-text" />

                                <input type="text" placeholder="Telefone" name="telefone" onChange={this.atualizarCadastroTelefone.bind(this)} className="input-text" />

                                <div>
                                    <input type="checkbox" id="vegana" onChange={this.atualizarCadastroVegana.bind(this)} />
                                    <label htmlFor="vegana">Possui opções veganas?</label>
                                </div>

                                <center>
                                    <h4>Categoria de preços</h4>
                                    <select className="categorias" id="categorias" onChange={this.atualizarCadastroVegana.bind(this)}>
                                        <option value="1">Menos de R$30,00</option>
                                        <option value="2">Entre R$31,00 e R$50,00</option>
                                        <option value="3">Mais de R$51,00</option>
                                    </select>

                                    <br />
                                    {this.state.erroCadastro !== '' ? <h5>{this.state.erroCadastro}</h5> : null}
                                    <input type="submit" className="input-btn" value="Fazer login" />
                                </center>
                            </form>
                        </div>
                    </div> : null
                }

            </div>
        )
    }
}