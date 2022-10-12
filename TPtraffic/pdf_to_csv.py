def pdf_to_csv(filename):
    from cStringIO import StringIO  #<-- added so you can copy/paste this to try it
    from pdfminer.converter import LTTextItem, TextConverter
    from pdfminer.pdfparser import PDFDocument, PDFParser
    from pdfminer.pdfinterp import PDFResourceManager, PDFPageInterpreter

    class CsvConverter(TextConverter):
        def __init__(self, *args, **kwargs):
            TextConverter.__init__(self, *args, **kwargs)

        def end_page(self, i):
            from collections import defaultdict
            lines = defaultdict(lambda : {})
            for child in self.cur_item.objs:
                if isinstance(child, LTTextItem):
                    (_,_,x,y) = child.bbox                   #<-- changed
                    line = lines[int(-y)]
                    line[x] = child.text.encode(self.codec)  #<-- changed

            for y in sorted(lines.keys()):
                line = lines[y]
                self.outfp.write(";".join(line[x] for x in sorted(line.keys())))
                self.outfp.write("\n")

    # ... the following part of the code is a remix of the 
    # convert() function in the pdfminer/tools/pdf2text module
    rsrc = PDFResourceManager()
    outfp = StringIO()
    device = CsvConverter(rsrc, outfp, codec="utf-8")  #<-- changed 
        # becuase my test documents are utf-8 (note: utf-8 is the default codec)

    doc = PDFDocument()
    fp = open(filename, 'rb')
    parser = PDFParser(fp)       #<-- changed
    parser.set_document(doc)     #<-- added
    doc.set_parser(parser)       #<-- added
    doc.initialize('')

    interpreter = PDFPageInterpreter(rsrc, device)

    for i, page in enumerate(doc.get_pages()):
        outfp.write("START PAGE %d\n" % i)
        interpreter.process_page(page)
        outfp.write("END PAGE %d\n" % i)

    device.close()
    fp.close()

    return outfp.getvalue()
