# 使い方
## BreakAnimGeneratorを表示する
「Tools」→「BreakAnimGenerator」を選択してください。
[![https://gyazo.com/5553dfb0ff6acf64c54ae563d29b2725](https://i.gyazo.com/5553dfb0ff6acf64c54ae563d29b2725.png)](https://gyazo.com/5553dfb0ff6acf64c54ae563d29b2725)

## 対象のゲームオブジェクトを設定する
[![https://gyazo.com/a4d88b5b2d97459902df81d93eae3631](https://i.gyazo.com/a4d88b5b2d97459902df81d93eae3631.png)](https://gyazo.com/a4d88b5b2d97459902df81d93eae3631)
①対象のGameObjectを追加します

②対象のGameObjectを選択します
        ドラッグ&ドロップ、◎から設定できます
	
③Meshを細かくするか設定します

④カットした際に切り口に貼るMaterialを設定します
        ドラッグ&ドロップ、◎から設定できます。

⑤細かさを決めます

⑥物理シミュレーションをAnimationClipに保存するかを設定します

⑦AnimationClipを保存するディレクトリを設定します
        ドラッグ&ドロップ、◎から設定できます。

⑧AnimationClipの名前を設定します

⑨AnimationClipのキーを保存する間隔を設定します

⑩どのTagを持つGameObjectがぶつかったときにアニメーションの保存を開始するか設定します

⑪設定を削除します

⑫エラーがある場合はここに表示されます

⑬設定を元に対象のGameObjectにComponentをアタッチします

⑭全ての設定を削除します

## AnimationClipを生成する
ゲームを再生し、設定したTagを持つゲームオブジェクトをぶつけてください。キーの登録が開始されます。登録の終了はデフォルトで **「Escapeキー」** に設定されています。変更するには以下のように **「Physics Anim Convertor」** の **「Stop Code」** から設定してください。
[![https://gyazo.com/96847aaa442c0d272c4a4b5430d92c5b](https://i.gyazo.com/96847aaa442c0d272c4a4b5430d92c5b.png)](https://gyazo.com/96847aaa442c0d272c4a4b5430d92c5b)

## sampleシーンについて
sampleでは **「Attacker」** が **「CutBuilding」** に接触することで登録が開始されます。Attackerを動かすには **「Aキー」** を入力してください。
