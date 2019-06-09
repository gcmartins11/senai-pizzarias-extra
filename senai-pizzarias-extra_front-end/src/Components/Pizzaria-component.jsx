import React, { Component } from 'react'
import './Pizzaria-Component.css'

export default class Pizzaria extends Component {
    constructor() {
        super()
        this.state = {
            
        }
    }

    render() {
        return (
            <div className="card-pizzaria">
                <p>Nome: </p><h3>{this.props.nome}</h3>

                <p>Endereço:</p><h3>Endereço: {this.props.endereco} - {this.props.numero}</h3>
                
                <p>Endereço: </p><h3>Telefone: {this.props.telefone}</h3>
                
                { this.props.vegana ? <h3>Sim</h3> : <h3>Não</h3>}
                
                <p>Preços: </p> 
                { this.props.categoria === 1 ? <h3>Até R$30,00</h3> : null } 
                { this.props.categoria === 2 ? <h3>De R$31,00 até R$50,00</h3> : null } 
                { this.props.categoria === 3 ? <h3>Acima de R$50,00</h3> : null } 
                
            </div>
        )
    }
}