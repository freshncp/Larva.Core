all: rebuild pack

pack:
	dotnet pack -c Release `pwd`/src/Larva.Core/
	mv `pwd`/src/Larva.Core/bin/Release/*.nupkg `pwd`/packages/
	dotnet pack -c Release `pwd`/src/Larva.Autofac/
	mv `pwd`/src/Larva.Autofac/bin/Release/*.nupkg `pwd`/packages/
	dotnet pack -c Release `pwd`/src/Larva.Log4Net/
	mv `pwd`/src/Larva.Log4Net/bin/Release/*.nupkg `pwd`/packages/
	dotnet pack -c Release `pwd`/src/Larva.NewtonsoftJson/
	mv `pwd`/src/Larva.NewtonsoftJson/bin/Release/*.nupkg `pwd`/packages/

test: test-core test-autofac test-log4net test-json

test-core:
	dotnet test `pwd`/src/Larva.Core.Tests/

test-autofac:
	dotnet test `pwd`/src/Larva.Autofac.Tests/

test-log4net:
	dotnet test `pwd`/src/Larva.Log4Net.Tests/

test-json:
	dotnet test `pwd`/src/Larva.NewtonsoftJson.Tests/

rebuild: clear build

build:
	dotnet build -c Release -f 'netstandard2.0' `pwd`/src/Larva.Core/
	dotnet build -c Release -f 'netstandard2.0' `pwd`/src/Larva.Autofac/
	dotnet build -c Release -f 'netstandard2.0' `pwd`/src/Larva.Log4Net/
	dotnet build -c Release -f 'netstandard2.0' `pwd`/src/Larva.NewtonsoftJson/

clear:
	rm -rf `pwd`/src/Larva.Core/bin/*
	rm -rf `pwd`/src/Larva.Core/obj/*
	rm -rf `pwd`/src/Larva.Autofac/bin/*
	rm -rf `pwd`/src/Larva.Autofac/obj/*
	rm -rf `pwd`/src/Larva.Log4Net/bin/*
	rm -rf `pwd`/src/Larva.Log4Net/obj/*
	rm -rf `pwd`/src/Larva.Log4Net/bin/*
	rm -rf `pwd`/src/Larva.Log4Net/obj/*
	rm -rf `pwd`/src/Larva.Core.Tests/bin/*
	rm -rf `pwd`/src/Larva.Core.Tests/obj/*
	rm -rf `pwd`/src/Larva.Autofac.Tests/bin/*
	rm -rf `pwd`/src/Larva.Autofac.Tests/obj/*
	rm -rf `pwd`/src/Larva.Log4Net.Tests/bin/*
	rm -rf `pwd`/src/Larva.Log4Net.Tests/obj/*
	rm -rf `pwd`/src/Larva.NewtonsoftJson.Tests/bin/*
	rm -rf `pwd`/src/Larva.NewtonsoftJson.Tests/obj/*
