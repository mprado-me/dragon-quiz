import json
import sys

def splitTypesAndValues(s):
	types = [];
	values = [];
	mode = "T";
	text = "";
	for j in range(0, len(s)):
		if(mode == "T"):
			if(s[j] == "["):
				if( len(text) > 0 ):
					types.append("T");
					values.append(text);
				mode = "I";
				text = "";
			else:
				text += s[j];
		elif(mode == "I"):
			if(s[j] == "]"):
				if( len(text) > 0 ):
					types.append("I");
					values.append(text);
				mode = "T";
				text = "";
			else:
				text += s[j];
	if( len(text) > 0 ):
		if(mode == 'T'):
			types.append("T");
			values.append(text);
		elif( mode == 'I' ):
			types.append("I");
			values.append(text);
	return (types, values);

in_file = open("C:\\Users\\Marco\\Desktop\\dragon-quiz\\Questions\\TableFormat\\"+sys.argv[1]+".txt", "r");
lines = in_file.read().split('\n');
in_file.close();
outJson = [];
for i in range(2, len(lines)):
	column = lines[i].split("|");
	if(column[0]=="//" ):
		continue;
	column = column[1:4];
	question = [];

	typesAndValues = splitTypesAndValues(column[0]);
	question.append(typesAndValues[0]);
	question.append(typesAndValues[1]);
	
	typesAndValues = splitTypesAndValues(column[1]);
	correctAnswer = [];
	correctAnswer.append(typesAndValues[0][0]);
	correctAnswer.append(typesAndValues[1][0]);
	question.append(correctAnswer);

	typesAndValues = splitTypesAndValues(column[2]);
	incorrectAnswer = [];
	incorrectAnswer.append(typesAndValues[0][0]);
	incorrectAnswer.append(typesAndValues[1][0]);
	question.append(incorrectAnswer);

	outJson.append(question);

with open("C:\\Users\\Marco\\Desktop\\dragon-quiz\\Questions\\JsonFormat\\"+sys.argv[1]+".txt", "w") as outfile:
    json.dump(outJson, outfile)