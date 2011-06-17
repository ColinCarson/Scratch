# FSharp build script
echo "Building FSharp file: $1.fs"
fsc $1.fs --out:/Users/Colin/Projects/build/$1.exe --reference:FSharp.PowerPack.Compatibility.dll --nowarn:62