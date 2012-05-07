using UnityEngine;
using System.Collections;

public class Atributo {
	private double valor;
	private double bonusEquipamento;
	private double buff;
	private double debuff;
	
	public double Valor {
		get {
			return this.valor;
		}
		set {
			valor = value;
		}
	}

	public double BonusEquipamento {
		get {
			return this.bonusEquipamento;
		}
		set {
			bonusEquipamento = value;
		}
	}

	public double Buff {
		get {
			return this.buff;
		}
		set {
			buff = value;
		}
	}

	public double Debuff {
		get {
			return this.debuff;
		}
		set {
			debuff = value;
		}
	}
	
}
